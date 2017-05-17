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
        /// 1、发布服务
        /// 2、本地包
        /// 3、覆盖现有
        /// </summary>
        public int Op { get; set; }
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
            public StrockStyle StrockStyle { get; set; }
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
        public double XMin { get; set; }
        public double YMin { get; set; }
        public double XMax { get; set; }
        public double YMax { get; set; }
    }
}
