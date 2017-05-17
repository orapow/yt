using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Utility;

namespace X.App.Views.services
{
    public class grid : xview
    {
        protected override string GetParmNames
        {
            get
            {
                return "sn-lv-x1-y1-x2-y2";
            }
        }
        public override byte[] GetResponse()
        {
            InitView();
            return Encoding.UTF8.GetBytes("网格服务" + Serialize.ToJson(dict));
        }
    }
}
