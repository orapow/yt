using System.Linq;
using X.Web.Com;

namespace X.App.Apis.poi
{
    public class load : xapi
    {
        public int tp { get; set; }

        protected override XResp Execute()
        {
            var q = from e in db.x_poi
                    where e.type == tp
                    select new
                    {
                        id = e.grid_id,
                        e.name,
                        e.img,
                        e.addr,
                        e.tel,
                        e.remark,
                        pts = Context.Server.HtmlDecode(e.x_grid.points),
                        st = Context.Server.HtmlDecode(e.x_grid.style),
                        gtp = e.x_grid.type,
                        e.type,
                        tpname = db.GetDictName("poi.type", e.type, ""),
                        lng = e.x_grid.lng,
                        lat = e.x_grid.lat
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
