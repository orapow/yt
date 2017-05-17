using System.Linq;
using X.Web.Com;

namespace X.App.Apis.floor
{
    public class save : xapi
    {
        public int id { get; set; }
        [ParmsAttr(name = "建筑物id", min = 1)]
        public int gid { get; set; }
        [ParmsAttr(name="楼层名称")]
        public string name { get; set; }
        [ParmsAttr(name="楼层值")]
        public int value { get; set; }
        /// <summary>
        /// 平面图
        /// </summary>
        public string bgimg { get; set; }

        protected override XResp Execute()
        {
            var ent = db.x_floor.FirstOrDefault(o => o.floor_id == id);
            if (ent == null) ent = new Data.x_floor();

            ent.name = name;
            ent.grid_id = gid;
            ent.value = value;
            ent.bgimg = bgimg;

            if (ent.floor_id == 0) db.x_floor.InsertOnSubmit(ent);

            SubmitDBChanges(db);

            return new XResp() { msg = ent.floor_id + "" };
        }
    }
}
