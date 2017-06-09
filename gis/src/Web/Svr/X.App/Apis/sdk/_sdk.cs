using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Utility;
using X.Web;

namespace X.App.Apis.sdk
{
    public class _sdk : xapi
    {
        protected string key = "KdEmuJLK8PEf&oYYe!kXN08z6izz^k0Q5qVtYb#^16zw5^D9B6$qxNd9yOlJedTt";
        protected override void InitApi()
        {
            base.InitApi();
            var sign = Context.Request.Form["sign"];
            if (string.IsNullOrEmpty(sign)) throw new XExcep("T签名参数丢失");

            var ps = new List<string>();
            foreach (string p in Context.Request.Form)
            {
                if (p == "sign") continue;
                ps.Add(p + "=" + Secret.ToBase64(Context.Request.Form[p]));
            }
            ps.Sort();
            var signed = Secret.SHA256(string.Join("", ps.ToArray()));
            if (sign.ToLower() != signed.ToLower()) throw new XExcep("T签名验证失败");
        }
    }
}
