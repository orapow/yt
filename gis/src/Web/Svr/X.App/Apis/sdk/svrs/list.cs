using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web.Com;

namespace X.App.Apis.sdk.svrs
{
    public class list : _sdk
    {
        public int st { get; set; }
        protected override XResp Execute()
        {
            var r = new Resp_List();
            var q = from s in db.x_service
                    select s;
            if (st > 0) q.Where(o => o.status == st);
            r.items = q.ToList().Select(o => new
            {
                id = o.service_id,
                o.name,
                o.dir,
                o.status
            });
            r.count = q.Count();
            return r;
        }
    }
}
