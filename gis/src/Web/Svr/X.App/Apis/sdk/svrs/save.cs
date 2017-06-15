using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.App.Com;
using X.Core.Cache;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.sdk.svrs
{
    public class save : _sdk
    {
        [ParmsAttr(name = "服务名称", req = true)]
        public string name { get; set; }
        public string sec_key { get; set; }
        protected override XResp Execute()
        {
            var s = db.x_service.FirstOrDefault(o => o.name == name);
            if (s != null) throw new XExcep("T服务名称已经存在");

            s = new x_service() { name = name, secret_key = sec_key, status = 2, version = cfg.version };
            db.x_service.InsertOnSubmit(s);
            db.SubmitDBChanges();

            return new XResp() { msg = s.service_id + "" };
        }
    }
}
