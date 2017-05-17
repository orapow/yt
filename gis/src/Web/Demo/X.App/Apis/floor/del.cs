using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web.Com;

namespace X.App.Apis.floor
{
    public class del : xapi
    {
        [ParmsAttr(name = "楼层id", min = 1)]
        public int id { get; set; }
        protected override XResp Execute()
        {
            var f = db.x_floor.FirstOrDefault(o => o.floor_id == id);
            db.x_point.DeleteAllOnSubmit(f.x_point);

            db.x_floor.DeleteOnSubmit(f);
            SubmitDBChanges(db);

            return new XResp();
        }
    }
}
