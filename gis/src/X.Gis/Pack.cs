using System;
using System.Collections.Generic;
using System.Drawing;

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
        public int BlockSize { get; set; }
        public int Version { get; set; }
        public DocumentInfo DocumentInfo { get; set; }
        public WaterMark WaterMarked { get; set; }
        public Cache Cached { get; set; }
        public Extend InitialExtend { get; set; }
        public Extend FullExtend { get; set; }
        public TileInfo MapTile { get; set; }
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
        public class TileInfo
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public int DPI { get; set; }
            public int Quality { get; set; }
            public string Format { get; set; }
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
        [X.Json.JsonIgnore]
        public List<Shape> Shapes { get; set; }
        public List<Field> Fields { get; set; }
        public string IDField { get; set; }
        public string DiaplsyField { get; set; }
        public DrawStyle Style { get; set; }
        public string OutPut { get; set; }

        public class Field
        {
            public string Name { get; set; }
            public int Length { get; set; }
            public string Alias { get; set; }
            public string Type { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
        public class Shape
        {
            /// <summary>
            /// 1、线
            /// 2、面
            /// </summary>
            public int Tp { get; set; }
            public string LayerNo { get; set; }
            public Dictionary<int, List<PointF>> Points { get; set; }
            public DrawStyle Style { get; set; }
            public string Name { get; set; }
            public Extend Extent { get; set; }
            public Dictionary<string, string> Data { get; set; }
            public Shape()
            {
                Points = new Dictionary<int, List<PointF>>();
            }
        }
    }
    public class DrawStyle
    {
        public int BorderWidth { get; set; }
        public int BorderTran { get; set; }
        public Color BorderColor { get; set; }
        public int FillTran { get; set; }
        public Color FillColor { get; set; }
        [X.Json.JsonIgnore]
        public Image Demo { get; set; }
    }
    public class Extend
    {
        public double xMax { get; set; }
        public double xMin { get; set; }
        public double yMax { get; set; }
        public double yMin { get; set; }
        public double xCenter
        {
            get
            {
                return (xMin + xMax) / 2;
            }
        }
        public double yCenter
        {
            get
            {
                return (yMin + yMax) / 2;
            }
        }
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
    public class Block
    {
        public int level { get; set; }
        public string file { get; set; }
        public Rectangle bound { get; set; }
    }
}
