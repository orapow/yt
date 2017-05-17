using System.Linq;
using X.Web.Com;

namespace X.App.Apis.point
{
    public class load : xapi
    {
        public int gid { get; set; }
        public int fid { get; set; }

        protected override XResp Execute()
        {
            var q = from e in db.x_point
                    where e.floor_id == fid
                    select new
                    {
                        id = e.point_id,
                        e.name,
                        pts = Context.Server.HtmlDecode(e.points),
                        st = Context.Server.HtmlDecode(e.style),
                        tp = e.type,
                        px = e.pointx,
                        py = e.pointy
                    };

            var r = new Resp_List()
            {
                items = q.ToList(),
                count = q.Count()
            };

            return r;
        }
    }
}
