using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using X.Core.Cache;
using X.Core.Utility;

namespace X.App.Views.services
{
    public class tiler : xview
    {
        public string sn { get; set; }
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

            var blocks = CacheHelper.Get<List<Block>>("svr." + sn);
            if (blocks == null)
            {
                var json = File.ReadAllText(Context.Server.MapPath("/svrs/" + sn + "/cfg.json"));
                if (string.IsNullOrEmpty(json)) return null;
                blocks = Serialize.FromJson<List<Block>>(json);
                if (blocks == null) return null;
            }

            var b = blocks.FirstOrDefault(o => o.level == lv && x >= o.bound.X && y >= o.bound.Y && x <= o.bound.X + 15 && y <= o.bound.Y + 15);
            if (b == null) return null;

            var bmp = Image.FromFile(Context.Server.MapPath(path + "/" + b.file));

            var img = new Bitmap(256, 256);
            var g = Graphics.FromImage(img);
            g.DrawImage(bmp, 0, 0, new Rectangle((x - b.bound.X) * 256, (y - b.bound.Y) * 256, 256, 256), GraphicsUnit.Pixel);
            g.Dispose();

            bmp.Dispose();

            var ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);
            img.Save("c:\\temp\\s\\" + x + "_" + y + "_" + lv + ".png", ImageFormat.Png);
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
