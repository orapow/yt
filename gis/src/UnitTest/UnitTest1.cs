using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Drawing;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //安徽省铜陵市铜陵县五松镇万鸡山社区荷塘月色花园小区15栋1单元1401室
            var t = Encoding.UTF8.GetString(Encoding.Unicode.GetBytes("瀹夊窘鐪侀摐闄靛競閾滈櫟鍘夸簲鏉鹃晣涓囬浮灞辩ぞ鍖鸿嵎濉樻湀鑹茶姳鍥皬鍖?5鏍?鍗曞厓1401瀹?"));
        }
        [TestMethod]
        public void MyTestMethod()
        {
            //var bmp = new Bitmap(;
        }

        //class XcImage : Image
        //{
        //    public XcImage(int w, int h) : base()
        //    {

        //    }
        //}
    }
}
