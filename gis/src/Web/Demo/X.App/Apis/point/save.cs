using System.Linq;
using System.Collections.Generic;
using X.Web.Com;
using X.Core.Utility;

namespace X.App.Apis.point
{
    public class save : xapi
    {
        public int id { get; set; }
        public int gid { get; set; }
        public int fid { get; set; }
        public int tp { get; set; }
        public string name { get; set; }
        public int px { get; set; }
        public int py { get; set; }
        public string ps { get; set; }
        public string fc { get; set; }
        public decimal fp { get; set; }
        public string bc { get; set; }
        public decimal bp { get; set; }
        public int bw { get; set; }

        protected override XResp Execute()
        {
            var ent = db.x_point.FirstOrDefault(o => o.point_id == id);
            if (ent == null) ent = new Data.x_point() { floor_id = fid };

            ent.name = name;
            if (tp > 0) ent.type = tp;

            if (px > 0) ent.pointx = px;
            if (px > 0) ent.pointy = py;
            if (!string.IsNullOrEmpty(ps)) ent.points = ps;

            if (!string.IsNullOrEmpty(fc) || !string.IsNullOrEmpty(bc))
            {
                var dt = new Dictionary<string, object>();
                dt.Add("fc", fc);
                dt.Add("fp", fp);
                dt.Add("bc", bc);
                dt.Add("bp", bp);
                dt.Add("bw", bw);
                ent.style = Context.Server.HtmlEncode(Serialize.ToJson(dt));
            }

            if (ent.point_id == 0) db.x_point.InsertOnSubmit(ent);

            SubmitDBChanges(db);

            return new XResp() { msg = ent.point_id + "" };
        }
    }
}
