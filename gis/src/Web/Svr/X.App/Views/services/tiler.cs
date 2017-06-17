using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using X.App.Com;
using X.Core.Cache;
using X.Core.Utility;

namespace X.App.Views.services
{
    public class tiler : _svr
    {
        public int lv { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "sn-lv-x-y";
            }
        }

        public override byte[] GetResponse()
        {
            InitView();
            if (string.IsNullOrEmpty(sn)) return null;

            Context.Response.ContentType = "image/png";

            var path = "/svrs/" + sn + "";

            if (File.Exists(Context.Server.MapPath(path + "/cache/" + lv + "_" + x + "_" + y))) Context.Server.Transfer(path + "/cache/" + lv + "_" + x + "_" + y);

            var blocks = CacheHelper.Get<List<x_block>>("svr." + sn + ".blocks");
            if (blocks == null && svr != null) blocks = svr.x_block.ToList();
            if (blocks == null) return null;
            CacheHelper.Save("svr." + sn + ".blocks", blocks);

            var b = blocks.FirstOrDefault(o => o.level == lv && x >= o.x && y >= o.y && x <= o.x + 15 && y <= o.y + 15);
            if (b == null) return null;

            var bmp = Image.FromFile(Context.Server.MapPath(path + "/" + b.file));

            var img = new Bitmap(256, 256);
            var g = Graphics.FromImage(img);
            g.DrawImage(bmp, 0, 0, new Rectangle((x - b.x.Value) * 256, (y - b.y.Value) * 256, 256, 256), GraphicsUnit.Pixel);
            g.Dispose();

            bmp.Dispose();

            var ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);
            img.Save(Context.Server.MapPath(path + "/cache/" + lv + "_" + x + "_" + y), ImageFormat.Png);
            img.Dispose();

            return ms.ToArray();

        }

        class Block
        {
            public int level { get; set; }
            public string file { get; set; }
            public Rectangle bound { get; set; }
        }

    }
}
