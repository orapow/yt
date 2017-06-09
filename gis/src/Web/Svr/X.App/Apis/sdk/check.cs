using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Utility;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.sdk
{
    public class check : _sdk
    {
        [ParmsAttr(name = "验证码", req = true)]
        public string code { get; set; }
        protected override XResp Execute()
        {
            var cd = Secret.MD5("K3@5Si8JNg6Me1K6gEz%3oFnEQsbu6tAaEPZSEZjbHTvpjxb9suWUd36ht69QQ^x");
            if (cd != code) throw new XExcep("T验证失败");
            return new XResp() { issucc = true, msg = Secret.MD5(key) };
        }
    }
}
