using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Gdal1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //var tiff = new Tiff(ofd.FileName);
                //var img = new Bitmap(50000, 80000, PixelFormat.Format8bppIndexed);
                //var img = tiff.Pics[0].GetImage(0, 0, 9689, 9689);
                //img.Save("d:\\7st.jpg", ImageFormat.Jpeg);

                //var img = Bmp.ResizeGrayscaleImage((Bitmap)Image.FromFile(ofd.FileName), 4096, 4096);
                //img.Save("d:\\7st.jpg", ImageFormat.Jpeg);

                //var image = new Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte>(ofd.FileName);
                //var newImage = image.Resize(4096, 5714, Emgu.CV.CvEnum.Inter.Nearest);
                //newImage.Save("d:\\7st.jpg");

                var tif = new Tiff(ofd.FileName);
                tif.Pics[0].CutImage(new Point(128, 50), new Size(28092, 39188));
                //img.Save("d:\\7s1t.jpg", ImageFormat.Jpeg);

                //tiff.Pics[0].CutImage(25000, 34875, 8192);

                //var sr = new FileStream(ofd.FileName, FileMode.Open);
                //var data = new byte[512];
                //sr.Read(data, 0, 512);

                //var img = Image.FromFile(ofd.FileName);
                //Bmp.Cut(ofd.FileName, 0, 0, 256, 256);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var bmp = new Bitmap(8192, 8192, PixelFormat.Format32bppArgb);
                var bd = bmp.LockBits(new Rectangle(0, 0, 8192, 8192), ImageLockMode.ReadWrite, bmp.PixelFormat);
                var data = File.ReadAllBytes(ofd.FileName).Take(8192 * 8192 * 3).ToArray();
                var ms = new MemoryStream();
                for (var i = 0; i < data.Length; i += 3)
                {
                    var dt = data.Skip(i * 3).Take(3).ToArray();
                    ms.Write(dt, 0, 3);
                    ms.WriteByte(0);
                }
                Marshal.Copy(ms.ToArray(), 0, bd.Scan0, (int)ms.Length);
                bmp.UnlockBits(bd);
                bmp.Save("d:\\8192.png", ImageFormat.Png);
                bmp.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var lins = File.ReadAllLines(ofd.FileName);
                var d = X.Core.Utility.Serialize.FromJson<List<List<List<object>>>>(lins[6]);
            }
        }
    }
}
