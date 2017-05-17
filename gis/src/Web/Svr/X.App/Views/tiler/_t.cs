using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace X.App.Views.tiler
{
    public class _t : xview
    {
        public string s { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public string l { get; set; }

        protected override string GetParmNames
        {
            get
            {
                return "s-x-y-l";
            }
        }

        protected virtual string urlTpl { get { return ""; } }

        public override byte[] GetResponse()
        {
            InitView();
            Context.Response.ContentType = "image/png";

            var ms = new MemoryStream();
            var bmp = new Bitmap(256, 256);
            var g = Graphics.FromImage(bmp);

            var url = urlTpl.Split(',');
            foreach (var u in url)
            {
                var data = downData(u.Replace("{s}", s).Replace("{x}", x).Replace("{y}", y).Replace("{l}", l));
                ms.Position = 0;
                ms.Write(data, 0, data.Length);
                g.DrawImage(Image.FromStream(ms), new Rectangle(0, 0, 256, 256), new Rectangle(0, 0, 256, 256), GraphicsUnit.Pixel);
            }

            ms.Position = 0;
            bmp.Save(ms, ImageFormat.Png);

            var imgdata = ms.ToArray();

            ms.Close();
            g.Dispose();
            bmp.Dispose();

            return imgdata;

        }

        byte[] downData(string url)
        {
            var wc = new Webc(5 * 1000);
            try
            {
                return wc.DownloadData(url);
            }
            catch
            {
                Thread.Sleep(3 * 1000);
                return downData(url);
            }
        }

        class Webc : WebClient
        {
            int to = 0;
            public Webc(int timeout)
            {
                to = timeout;
            }
            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
                request.Timeout = to;
                request.ReadWriteTimeout = to;
                return request;
            }
        }

    }
}
