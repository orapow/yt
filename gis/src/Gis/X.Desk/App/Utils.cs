using Interop.MapWinGIS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using X.Gis;

namespace X.Desk
{
    public class Utils
    {
        public static int GetDist(PointF p1, PointF p2)
        {
            return (int)Math.Ceiling(Math.Abs(Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2))) * 256);
        }
        public static RectangleF GetRect(Extend ext, int lv)
        {
            var lt = WorldToGps(ext.xMin, ext.yMax, lv);
            var rt = WorldToGps(ext.xMax, ext.yMax, lv);
            var lb = WorldToGps(ext.xMin, ext.yMin, lv);
            return new RectangleF(lt.X, lt.Y, GetDist(lt, rt), GetDist(lt, lb));
        }
        public static PointF WorldToGps(double lon, double lat, int zoom)
        {
            var p = new PointF();
            p.X = (float)((lon + 180.0) / 360.0 * (1 << zoom));
            p.Y = (float)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) + 1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom));
            return p;
        }
        public static PointF GpsToWorld(float x, float y, int zoom)
        {
            var p = new PointF();
            p.X = x / (1 << zoom) * 360 - 180; //(float)(x / 256.0 / (1 << zoom)) * 360 - 180;
            p.Y = (float)(Math.Atan(Math.Sinh(Math.PI - 2 * Math.PI * y / (1 << zoom))) * 180 / Math.PI);
            return p;
        }
    }
}
