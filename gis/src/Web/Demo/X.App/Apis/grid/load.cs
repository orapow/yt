using System.Linq;
using X.Web.Com;

namespace X.App.Apis.grid
{
    public class load : xapi
    {
        public decimal xmin { get; set; }
        public decimal ymin { get; set; }
        public decimal xmax { get; set; }
        public decimal ymax { get; set; }

        public int page { get; set; }
        public int limit { get; set; }

        protected override XResp Execute()
        {
            var q = from e in db.x_grid
                    where e.lng >= xmin && e.lng <= xmax && e.lat >= ymin && e.lat <= ymax
                    select new
                    {
                        id = e.grid_id,
                        e.name,
                        pts = e.points,
                        e.lng,
                        e.lat,
                        e.style,
                        tp = e.type
                    };

            if (page == 0) page = 1;
            //if (limit == 0) limit = 500;

            if (limit > 0) q = q.Skip((page - 1) * limit).Take(limit);
            var r = new Resp_List()
            {
                items = q.ToList(),
                count = q.Count()
            };

            return r;
        }
    }
}
