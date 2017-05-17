using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using X.Core.Utility;
using X.Data;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.grid
{
    public class inport : xapi
    {
        protected override XResp Execute()
        {
            var json = new StreamReader(Context.Request.InputStream).ReadToEnd();
            if (string.IsNullOrEmpty(json)) throw new XExcep("T数据为空或格式不正确");

            var list = Serialize.FromJson<List<x_grid>>(json);
            if (list == null) throw new XExcep("T数据为空或格式不正确");

            var pc = Math.Ceiling(list.Count() / 50.0);
            var p = 1;
            do
            {
                var gs = list.Skip((p - 1) * 50).Take(50);
                if (gs == null || gs.Count() == 0) break;
                db.x_grid.InsertAllOnSubmit(gs);
                p++;
            } while (true);

            SubmitDBChanges(db);

            return new XResp();
        }
    }
}
