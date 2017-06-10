using System;
using System.Linq;
using System.Collections.Generic;
using X.Core.Cache;

namespace X.App
{
    partial class DBDataContext
    {
        /// <summary>
        /// 获取字典文字
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value">
        /// 多个值用 , 隔开
        /// </param>
        /// <returns></returns>
        public override string GetDictName(string code, object value, string split)
        {
            if (value == null || string.IsNullOrEmpty(code)) return string.Empty;
            var list = GetDictList(code, "00");
            if (list == null || list.Count == 0) return string.Empty;

            var val = (value + "").Trim().Split(',');
            var dicts = list.Where(o =>
            {
                return val.Contains(o.Value); //val.IndexOf(String.Format(",{0},", o.value)) >= 0;
            });
            if (dicts == null || dicts.Count() == 0) return string.Empty;
            var ns = string.Empty;
            foreach (var d in dicts)
            {
                if (!string.IsNullOrEmpty(ns))
                {
                    ns += split;
                }
                ns += d.Key;
            }
            return ns;
        }

        /// <summary>
        /// 获取字典列表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="upval"></param>
        /// <returns></returns>
        public override Dictionary<string, string> GetDictList(string code, string upval)
        {
            var key = "dict." + code;
            var list = CacheHelper.Get<List<x_dict>>(key);
            if (list == null || list.Count == 0)
            {
                var q = from c in x_dict
                        where c.code == code
                        select c;
                list = q.ToList();
                if (list == null || list.Count == 0) return null;
                CacheHelper.Save(key, list);
            }
            if (upval == "00") return list.ToDictionary(k => k.name, v => v.value);
            if (string.IsNullOrEmpty(upval) || upval == "0") return list.FindAll(o => { return o.upval == "0"; }).ToDictionary(k => k.name, v => v.value);
            else
            {
                var u = list.FirstOrDefault(o => o.value == upval.Split('-').Last());
                return list.FindAll(o => { return o.upval == (u.upval == "0" ? u.value : u.upval + "-" + u.value); }).ToDictionary(k => k.name, v => v.value);
            }
        }
    }
    partial class x_dict
    {
        public long id { get { return dict_id; } }
    }
}