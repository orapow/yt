using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace X.Gis
{
    public class Svr
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 服务器目录
        /// </summary>
        public string Dir { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string Key { get; set; }
        public Size BlockSize { get; set; }
        public DocumentInfo DocumentInfo { get; set; }
        public WaterMark WaterMarked { get; set; }
        public Cache Cached { get; set; }
        public Extend InitialExtend { get; set; }
        public Extend FullExtend { get; set; }
        public class WaterMark
        {
            public bool Enabel { get; set; }
            public Image Img { get; set; }
            public int Transparent { get; set; }
        }
        public class Cache
        {
            public bool UseMemory { get; set; }
            public int MinMem { get; set; }
            public int MaxMem { get; set; }
            public bool UserFile { get; set; }
        }
    }
    public class DocumentInfo
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Comments { get; set; }
        public string Subject { get; set; }
        public string Category { get; set; }
        public string Desc { get; set; }
    }
    public class TileInfo
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int DPI { get; set; }
        public int Quality { get; set; }
        public string Format { get; set; }
    }
    public class Layer
    {
        public string Name { get; set; }
        /// <summary>
        /// 1、图像
        /// 2、图形
        /// </summary>
        public int Tp { get; set; }
        public string File { get; set; }
        public Extend Extends { get; set; }
        public string Desc { get; set; }
        public string Copyright { get; set; }
        public override string ToString()
        {
            return "[" + (Tp == 1 ? "图像" : "图形") + "]->" + Name;
        }
    }
    public class ImgLayer : Layer
    {
        public Color TransparentColor { get; set; }
    }
    public class ShpLayer : Layer
    {
        public List<Field> Fields { get; set; }
        public string IDField { get; set; }
        public string DiaplsyField { get; set; }
        public DrawInfo Style { get; set; }
        public OutType OutPut { get; set; }

        public enum OutType
        {
            /// <summary>
            /// 图形
            /// </summary>
            Img,
            /// <summary>
            /// 网格
            /// </summary>
            Grid
        }

        public class DrawInfo
        {
            public string StrockStyle { get { return "Solid"; } }
            public int StrockWidth { get; set; }
            public int StrockTransparent { get; set; }
            public Color StrockColor { get; set; }
            public Color FillColor { get; set; }
            public int FillTransparent { get; set; }
        }
        public enum StrockStyle
        {

        }
        public class Field
        {
            public string Name { get; set; }
            public int Length { get; set; }
            public string Alias { get; set; }
            public string Type { get; set; }
            public bool Selected { get; set; }
        }
    }
    public class Extend
    {
        public double xMax { get; set; }
        public double xMin { get; set; }
        public double yMax { get; set; }
        public double yMin { get; set; }
        public void SetBound(Extend ext)
        {
            xMin = xMin == 0 ? ext.xMin : Math.Min(xMin, ext.xMin);
            yMin = yMin == 0 ? ext.yMin : Math.Min(yMin, ext.yMin);
            xMax = xMax == 0 ? ext.xMax : Math.Max(xMax, ext.xMax);
            yMax = yMax == 0 ? ext.yMax : Math.Max(yMax, ext.yMax);
        }
        public Extend(double xMin, double yMin, double xMax, double yMax)
        {
            this.xMax = xMax;
            this.xMin = xMin;
            this.yMin = yMin;
            this.yMax = yMax;
        }
        public Extend() { }
    }
    public class Shape
    {
        /// <summary>
        /// 1、线
        /// 2、面
        /// </summary>
        public int Tp { get; set; }
        public Dictionary<int, List<PointF>> Points { get; set; }
        public Shape()
        {
            Points = new Dictionary<int, List<PointF>>();
        }
    }
}
