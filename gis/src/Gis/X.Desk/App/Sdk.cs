using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Utility;

namespace X.Desk
{
    public class Sdk
    {
        static string gateway = "";
        static string key = "KdEmuJLK8PEf&oYYe!kXN08z6izz^k0Q5qVtYb#^16zw5^D9B6$qxNd9yOlJedTt";

        static T HttpPost<T>(string api, Dictionary<string, string> ps) where T : Resp
        {
            try
            {
                var json = "";
                var url = api.StartsWith("http") ? api : gateway + "api/" + api;

                var _ps = new List<string>();
                foreach (var p in ps.Keys) _ps.Add(p + "=" + Secret.ToBase64(ps[p]));
                _ps.Sort();

                ps.Add("sign", Secret.SHA256(string.Join("", _ps)));
                json = Tools.PostHttpData(url, ps);

                return Serialize.FromJson<T>(json);
            }
            catch (Exception ex)
            {
                return new Resp() { issucc = false, msg = ex.Message } as T;
            }
        }
        static bool Check(string url)
        {
            var rsp = HttpPost<Resp>(url.TrimEnd('/') + "/api/sdk.check", new Dictionary<string, string>() { { "code", Secret.MD5("K3@5Si8JNg6Me1K6gEz%3oFnEQsbu6tAaEPZSEZjbHTvpjxb9suWUd36ht69QQ^x") } });
            if (!rsp.issucc) return false;
            return rsp.msg == Secret.MD5(key);
        }

        public static void SetUrl(string url)
        {
            if (!Check(url)) throw new Exception("链接验证失败");
            gateway = url;
        }
        public static DirsRsp GetDirs()
        {
            return HttpPost<DirsRsp>("sdk.dirs", null);
        }
        public static SvrsRsp GetSvrs()
        {
            return HttpPost<SvrsRsp>("sdk.svrs", null);
        }

        public class DirsRsp : Resp
        {
            public List<string> items { get; set; }
        }
        public class SvrsRsp : Resp
        {
            public List<Svr> items { get; set; }
            public class Svr
            {
                public string name { get; set; }
                public string dir { get; set; }
                public string status { get; set; }
                public override string ToString()
                {
                    return "[" + dir + "](" + status + ")" + name;
                }
            }
        }
        public class Resp
        {
            public bool issucc { get; set; }
            public string code { get; set; }
            public string msg { get; set; }
        }
    }
}
