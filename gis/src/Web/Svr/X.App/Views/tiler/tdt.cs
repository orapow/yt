using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using X.Core.Utility;

namespace X.App.Views.tiler
{
    public class tdt : _t
    {
        /// <summary>
        /// vec_w
        /// img_w
        /// </summary>
        public string t { get; set; }

        protected override string GetParmNames
        {
            get
            {
                return "t-" + base.GetParmNames;
            }
        }

        protected override string urlTpl
        {
            get
            {
                if (string.IsNullOrEmpty(t)) t = "vec_c";
                //return "http://t{s}.tianditu.com/DataServer?T=" + t + "&x={x}&y={y}&l={l},http://t{s}.tianditu.com/DataServer?T=cva_" + t.Split('_')[1] + "&x={x}&y={y}&l={l}";
                //http://t6.tianditu.com/img_c/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=img&STYLE=default&TILEMATRIXSET=c&FORMAT=tiles&TILECOL=3376&TILEROW=569&TILEMATRIX=12
                //http://t6.tianditu.com/vec_c/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=vec&STYLE=default&TILEMATRIXSET=c&FORMAT=tiles&TILECOL=3376&TILEROW=569&TILEMATRIX=12
                var p = t.Split('_');
                return "http://t{s}.tianditu.cn/" + t + "/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=" + p[0] + "&STYLE=default&TILEMATRIXSET=" + p[1] + "&FORMAT=tiles&TILEMATRIX={l}&TILEROW={y}&TILECOL={x},http://t{s}.tianditu.cn/cva_" + p[1] + "/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=cva&STYLE=default&TILEMATRIXSET=" + p[1] + "&FORMAT=tiles&TILEMATRIX={l}&TILEROW={y}&TILECOL={x}";
            }
        }

    }
}
