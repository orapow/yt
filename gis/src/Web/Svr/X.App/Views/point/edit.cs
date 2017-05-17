using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Utility;

namespace X.App.Views.point
{
    public class edit : xview
    {
        public int id { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "id";
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            if (id > 0)
            {
                var ent = db.x_point.FirstOrDefault(o => o.point_id == id);
                if (ent != null) dict.Add("item", ent);
                if (ent.type != 1 && !string.IsNullOrEmpty(ent.style))
                {
                    var d = Serialize.JsonToDict(Context.Server.HtmlDecode(ent.style));
                    dict.Add("fc", d["fc"]);
                    dict.Add("fp", d["fp"]);
                    dict.Add("bc", d["bc"]);
                    dict.Add("bp", d["fp"]);
                    dict.Add("bw", d["bw"]);
                }
                else
                {
                    dict.Add("fc", "#00ff00");
                    dict.Add("fp", 0.3);
                    dict.Add("bc", "#0000ff");
                    dict.Add("bp", 0.8);
                    dict.Add("bw", 2);
                }
            }
        }
    }
}
