using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web.Com;

namespace X.App.Apis.sdk.dirs
{
    public class list : _sdk
    {
        protected override XResp Execute()
        {
            var r = new Resp_List();
            var q = db.GetDictList("yt.dir", "0");
            r.items = q.ToList().Select(o => new { o.name, o.value });
            r.count = q.Count();
            return r;
        }
    }
}
