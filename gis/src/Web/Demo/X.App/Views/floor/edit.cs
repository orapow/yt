using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.floor
{
    public class edit : xview
    {
        public int id { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "gid-id";
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            if (id > 0)
            {
                var ent = db.x_floor.FirstOrDefault(o => o.floor_id == id);
                if (ent != null) dict.Add("item", ent);
            }
        }
    }
}
