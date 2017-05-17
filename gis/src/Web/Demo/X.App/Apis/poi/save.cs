using System.Linq;
using System.Collections.Generic;
using X.Web.Com;
using X.Core.Utility;

namespace X.App.Apis.poi
{
    public class save : xapi
    {
        public int tp { get; set; }
        public int gid { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public string addr { get; set; }
        public string tel { get; set; }
        public string remark { get; set; }

        protected override XResp Execute()
        {
            var ent = db.x_poi.FirstOrDefault(o => o.grid_id == gid);
            if (ent == null) ent = new Data.x_poi() { grid_id = gid };

            ent.name = name;
            ent.addr = addr;
            ent.img = img;
            ent.remark = remark;
            ent.tel = tel;
            ent.type = tp;

            if (ent.poi_id == 0) db.x_poi.InsertOnSubmit(ent);

            SubmitDBChanges(db);

            return new XResp();
        }
    }
}
