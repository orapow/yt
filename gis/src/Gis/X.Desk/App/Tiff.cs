using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace X.Desk
{
    public class Tiff
    {
        public IFH Head = null;
        public List<IFD> Pics = null;

        public Tiff(string filename)
        {
            Head = new IFH(filename);
            Pics = new List<IFD>();
            Pics.Add(new IFD(Head));
        }

        public class IFH
        {
            public IFH(string file)
            {
                var fs = new FileStream(file, FileMode.Open);
                if (fs == null || !fs.CanRead) throw new Exception("文件对象为空或不可读");
                var data = new byte[8];
                fs.Read(data, 0, 8);
                File = file;
                Bit = Encoding.ASCII.GetString(data.Take(2).ToArray());
                Flag = (UInt16)getValue(data.Skip(2).Take(2), 3);
                IFD = (UInt32)getValue(data.Skip(4).Take(4), 4);
                fs.Close();
            }

            public object getValue(IEnumerable<byte> dt, int tp)
            {
                if (Bit == "MM") dt = dt.Reverse();
                var data = dt.ToArray();
                switch (tp)
                {
                    case 1:
                        return data[0];
                    case 2:
                        return BitConverter.ToChar(data, 0);
                    case 3:
                        return BitConverter.ToUInt16(data, 0);
                    case 4:
                        return BitConverter.ToUInt32(data, 0);
                    case 5:
                        return BitConverter.ToUInt32(data, 0);
                    case 6:
                        return data[0];
                    case 7:
                        return BitConverter.ToChar(data, 0);
                    case 8:
                        return BitConverter.ToInt16(data, 0);
                    case 9:
                        return BitConverter.ToInt32(data, 0);
                    case 10:
                        return BitConverter.ToUInt32(data, 0);
                    case 11:
                        return BitConverter.ToSingle(data, 0);
                    case 12:
                        return BitConverter.ToSingle(data, 0);
                    default:
                        return null;
                }
            }

            public string File { get; set; }
            public string Bit { get; private set; }
            public int Flag { get; private set; }
            public long IFD { get; private set; }
        }
        public class IFD
        {
            /// <summary>
            /// 获取图片
            /// </summary>
            /// <param name="rect"></param>
            /// <returns></returns>
            public Image GetImage(Rectangle rect, Size zoom)
            {
                int w = zoom.Width, h = zoom.Height;
                var rw = (float)(Width) / w;
                var rh = (float)(Height) / h;
                var fs = new FileStream(Head.File, FileMode.Open);

                int pw = Math.Min(w, rect.Width), ph = Math.Min(h, rect.Height);
                var os = new Point(Math.Abs(Math.Min(rect.X, 0)), Math.Abs(Math.Min(rect.Y, 0)));

                var imgw = Math.Min(pw + os.X, w) - os.X;
                var imgh = Math.Min(ph + os.Y, h) - os.Y;

                if (imgw < 0 || imgh < 0) { fs.Close(); return null; }
                
                try
                {
                    var bmp = new Bitmap(imgw, imgh, PixelFormat.Format32bppArgb);
                    var bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                    var of = bd.Scan0;
                    for (var i = os.Y; i < Math.Min(ph + os.Y, h); i++)
                    {
                        var y0 = i * rh;
                        var u = y0 - (int)y0;

                        fs.Seek(Pos + (int)y0 * Stride, SeekOrigin.Begin);
                        var row = new byte[Stride * 3];
                        fs.Read(row, 0, row.Length);

                        for (var x = os.X; x < Math.Min(pw + os.X, w); x++)
                        {
                            var x0 = x * 4 * rw;
                            var v = x0 - (int)x0;
                            var x1 = (int)(x0) - ((int)x0 % 4 == 0 ? 0 : (int)x0 % 4);
                            var x2 = x1 + 4;
                            var x3 = Stride + x1;
                            var x4 = x3 + 4;

                            var r = (1 - u) * (1 - v) * row[x1 + 2] + (1 - u) * v * row[x3 + 2] + u * (1 - v) * row[x2 + 2] + u * v * row[x4 + 2];
                            var g = (1 - u) * (1 - v) * row[x1 + 1] + (1 - u) * v * row[x3 + 1] + u * (1 - v) * row[x2 + 1] + u * v * row[x4 + 1];
                            var b = (1 - u) * (1 - v) * row[x1 + 0] + (1 - u) * v * row[x3 + 0] + u * (1 - v) * row[x2 + 0] + u * v * row[x4 + 0];
                            
                            Marshal.Copy(new byte[] { (byte)r, (byte)g, (byte)b, row[x1 + 3] }, 0, of, 4);
                            of = IntPtr.Add(of, 4);
                        }
                    }
                    bmp.UnlockBits(bd);
                    return bmp;
                }
                catch { }
                finally
                {
                    fs.Close();
                }
                return null;
            }

            /// <summary>
            /// 切割图片
            /// </summary>
            /// <param name="os">偏移</param>
            /// <param name="blk">块大小</param>
            /// <param name="dst">目标总大小</param>
            /// <returns></returns>
            public void CutImage(Point os, Size dst)
            {
                int w = dst.Width, h = dst.Height;
                var rw = (float)(Width) / w;
                var rh = (float)(Height) / h;
                var fs = new FileStream(Head.File, FileMode.Open);

                var c = (int)Math.Ceiling(w / 8192.0);
                var blocks = new List<MemoryStream>();//块数据
                var block_y = 0;//块的y坐标

                for (var i = 0; i < c; i++) blocks.Add(new MemoryStream());

                var ir = 1;
                for (var y = 0; y < h; y++)
                {
                    var y0 = y * rh;
                    var u = y0 - (int)y0;
                    fs.Seek(Pos + (int)y0 * Stride, SeekOrigin.Begin);
                    var row = new byte[Stride * (int)(rh)];
                    fs.Read(row, 0, row.Length);

                    for (var x = 0; x < w; x++)
                    {
                        var x0 = x * 3 * rw;
                        var v = x0 - (int)x0;
                        var x1 = (int)(x0) - ((int)x0 % 3 == 0 ? 0 : (int)x0 % 3);
                        var x2 = x1 + 3;
                        var x3 = Stride * (int)(rh / 2) + x1;
                        var x4 = x3 + 3;

                        var r = (1 - u) * (1 - v) * row[x1 + 2] + (1 - u) * v * row[x3 + 2] + u * (1 - v) * row[x2 + 2] + u * v * row[x4 + 2];
                        var g = (1 - u) * (1 - v) * row[x1 + 1] + (1 - u) * v * row[x3 + 1] + u * (1 - v) * row[x2 + 1] + u * v * row[x4 + 1];
                        var b = (1 - u) * (1 - v) * row[x1 + 0] + (1 - u) * v * row[x3 + 0] + u * (1 - v) * row[x2 + 0] + u * v * row[x4 + 0];

                        blocks[(int)Math.Floor(x / 8192.0)].Write(new byte[] { (byte)r, (byte)g, (byte)b }, 0, 3);
                    }

                    for (var b = blocks[c - 1].Length; b < blocks[c - 2].Length; b += 3) blocks[c - 1].Write(new byte[] { 255, 255, 255 }, 0, 3);

                    if (ir % 512 == 0 && y > 0 || ir == 8192 || y == h - 1)
                    {
                        byte[] nodata = null;
                        if (y == h - 1 && ir < 8192)
                        {
                            nodata = new byte[(8192 - ir - ir % 512 + 512) * 8192 * 3];
                            for (var i = 0; i < nodata.Length; i++) nodata[i] = 255;
                        }
                        for (var bi = 0; bi < blocks.Count; bi++)
                        {
                            if (nodata != null && nodata.Length > 0) blocks[bi].Write(nodata, 0, nodata.Length);
                            var f = File.Open(Application.StartupPath + "\\" + block_y + "" + bi + ".xdt", FileMode.OpenOrCreate);
                            f.Seek((ir - 512) * 8192 * 3, SeekOrigin.Begin);
                            blocks[bi].WriteTo(f);
                            f.Close();
                            blocks[bi] = new MemoryStream();
                        }
                    }
                    ir++;
                    if (ir == 8193)
                    {
                        block_y++;
                        ir = 1;
                    }
                }
                fs.Close();
            }

            public IFD(IFH h)
            {
                Head = h;
                var fs = new FileStream(h.File, FileMode.Open);
                fs.Seek(h.IFD, SeekOrigin.Begin);

                var ct = new byte[2];
                fs.Read(ct, 0, 2);

                Count = Convert.ToInt32(h.getValue(ct, 3));

                Des = new List<DE>();
                for (var i = 0; i < Count; i++)
                {
                    var de = new byte[12];
                    fs.Seek(10 + i * 12, SeekOrigin.Begin);
                    fs.Read(de, 0, 12);
                    var d = new DE(de, fs, this);
                    Des.Add(d);
                }

                Width = Convert.ToUInt32(Des.FirstOrDefault(o => o.Tag == 256).Value);
                Height = Convert.ToUInt32(Des.FirstOrDefault(o => o.Tag == 257).Value);
                Pos = Convert.ToInt64(Des.FirstOrDefault(o => o.Tag == 273).Value);
                Stride = Convert.ToInt64(Des.FirstOrDefault(o => o.Tag == 279).Value) / Height;

                fs.Seek(10 + Count * 12, SeekOrigin.Begin);
                var nt = new byte[4];
                fs.Read(nt, 0, 4);
                Next = BitConverter.ToInt32(nt, 0);

                fs.Close();
            }
            public IFH Head { get; set; }
            public int Count { get; private set; }
            List<DE> Des { get; set; }
            public long Pos { get; private set; }
            public long Width { get; private set; }
            public long Height { get; private set; }
            public long Stride { get; set; }
            public long Next { get; private set; }
        }

        class DE
        {
            Dictionary<int, int> tps = new Dictionary<int, int>() { { 1, 1 }, { 2, 1 }, { 3, 2 }, { 4, 4 }, { 5, 8 }, { 6, 1 }, { 7, 1 }, { 8, 2 }, { 9, 4 }, { 10, 8 }, { 11, 4 }, { 12, 8 } };
            public DE(byte[] de, FileStream fs, IFD fd)
            {
                Tag = (ushort)fd.Head.getValue(de.Take(2), 3); //BitConverter.ToUInt16(ifh.Bit == "MM" ? .Reverse().ToArray() : de.Take(2).ToArray(), 0);
                if (Tag != 256 && Tag != 257 && Tag != 273 && Tag != 279) return;
                Type = (ushort)fd.Head.getValue(de.Skip(2).Take(2), 3); //BitConverter.ToUInt16(ifh.Bit == "MM" ? de.Skip(2).Take(2).Reverse().ToArray() : de.Skip(2).Take(2).ToArray(), 0);
                Length = (uint)fd.Head.getValue(de.Skip(4).Take(4), 4);// BitConverter.ToUInt32(ifh.Bit == "MM" ? de.Skip(4).Take(4).Reverse().ToArray() : de.Skip(4).Take(4).ToArray(), 0);
                var v = Convert.ToInt64(fd.Head.getValue(de.Skip(8).Take(4), Type));
                if (Length * Type > 4)
                {
                    try
                    {
                        fs.Seek(v, SeekOrigin.Begin);
                        var dt = new byte[Length * (ulong)tps[Type]];
                        fs.Read(dt, 0, dt.Length);
                        Value = dt;
                    }
                    catch { }
                }
                else Value = v;
            }

            public ushort Tag { get; private set; }
            public ushort Type { get; private set; }
            public ulong Length { get; private set; }
            public object Value { get; private set; }
        }
    }
}
