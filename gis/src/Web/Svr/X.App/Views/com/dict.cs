using System.Collections.Generic;
using System.Linq;
using X.Data;

namespace X.App.Views.com
{
    public class dict : xview
    {
        public string code { get; set; }
        protected override void InitDict()
        {
            base.InitDict();
            if (dict.GetInt("bylet") == 1)
            {
                dict.Add("list", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList());
            }
            else
            {
                //var upval = dict.GetString("upval");
                //if (string.IsNullOrEmpty(upval)) upval = "0";
                dict.Add("dict", db.GetDictList(code, dict.GetString("upval")).Select(o => new { value = o.Value, name = o.Key }).ToList());
            }
        }

        protected override string GetParmNames
        {
            get
            {
                ///代号-上级值-按字母排
                return "code-upval-bylet";
            }
        }

        public List<x_dict> GetByLetter(char l)
        {
            //var list = db.GetDictList(dict.GetString("code"), "00");
            //return list.Where(d =>
            //{
            //    return d..ToUpper()[0] == l && d.upval == dict.GetString("upval");
            //});
            return null;
        }
    }
}
