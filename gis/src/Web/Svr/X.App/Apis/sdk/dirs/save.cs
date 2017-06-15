using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.App.Com;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.sdk.dirs
{
    public class save : _sdk
    {
        [ParmsAttr(name = "文件夹名称", req = true, len = "3,20")]
        public string name { get; set; }
        protected override XResp Execute()
        {
            var d = db.GetDict("yt.dir", name);
            if (d != null) throw new XExcep("T文件夹已经存在");

            d = new x_dict() { name = name, value = name, upval = "0", code = "yt.dir" };
            db.x_dict.InsertOnSubmit(d);
            db.SubmitDBChanges();

            db.ClearDict("yt.dir");

            return new XResp();
        }
    }
}
