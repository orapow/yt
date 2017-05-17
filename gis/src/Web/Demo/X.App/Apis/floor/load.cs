using System.Linq;
using X.Web.Com;

namespace X.App.Apis.floor
{
    public class load : xapi
    {
        public int gid { get; set; }

        protected override XResp Execute()
        {
            var q = from e in db.x_floor
                    where e.grid_id == gid
                    select new
                    {
                        id = e.floor_id,
                        e.name,
                        e.bgimg,
                        e.value
                    };

            var r = new Resp_List()
            {
                items = q.OrderByDescending(o => o.value).ToList(),
                count = q.Count()
            };

            return r;
        }
    }
}
