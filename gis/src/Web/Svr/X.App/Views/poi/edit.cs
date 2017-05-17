using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Utility;

namespace X.App.Views.poi
{
    public class edit : xview
    {
        public int gid { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "gid";
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            if (gid > 0)
            {
                var ent = db.x_poi.FirstOrDefault(o => o.grid_id == gid);
                if (ent != null) dict.Add("item", ent);
            }
        }
    }
}
