using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Utility;

namespace X.App.Views
{
    public class check : xview
    {
        public string code { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "code";
            }
        }
        public override byte[] GetResponse()
        {
            InitView();
            var cd = Secret.MD5("K3@5Si8JNg6Me1K6gEz%3oFnEQsbu6tAaEPZSEZjbHTvpjxb9suWUd36ht69QQ^x");
            if (cd == code) return Encoding.UTF8.GetBytes(Secret.MD5("KdEmuJLK8PEf&oYYe!kXN08z6izz^k0Q5qVtYb#^16zw5^D9B6$qxNd9yOlJedTt"));
            return null;
        }
        protected override void InitView()
        {
            base.InitView();



        }
    }
}
