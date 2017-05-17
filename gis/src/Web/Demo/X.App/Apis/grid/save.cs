using System.Linq;
using X.Web.Com;

namespace X.App.Apis.grid
{
    public class save : xapi
    {
        public int id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 样式
        /// Json数据
        /// </summary>
        public string style { get; set; }
        /// <summary>
        /// 类型
        /// 1、点
        /// 2、圆
        /// 3、线
        /// 4、多边型
        /// 5、四方型
        /// </summary>
        public int tp { get; set; }
        /// <summary>
        /// 中心经度
        /// </summary>
        public decimal lng { get; set; }
        /// <summary>
        /// 中心纬度
        /// </summary>
        public decimal lat { get; set; }
        /// <summary>
        /// 坐标集
        /// Json数据
        /// </summary>
        public string pts { get; set; }

        protected override XResp Execute()
        {
            var gd = db.x_grid.FirstOrDefault(o => o.grid_id == id);
            if (gd == null) gd = new Data.x_grid();

            gd.lat = lat;
            gd.lng = lng;
            gd.name = name;
            gd.points = pts;
            gd.style = style;
            gd.type = tp;

            if (gd.grid_id == 0) db.x_grid.InsertOnSubmit(gd);

            SubmitDBChanges(db);

            return new XResp() { msg = gd.grid_id + "" };
        }
    }
}
