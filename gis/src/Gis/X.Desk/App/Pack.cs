using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace X.Desk
{
    public class Pack
    {
        /// <summary>
        /// 1、发布服务
        /// 2、本地包
        /// 3、覆盖现有
        /// </summary>
        public int Op { get; set; }
        /// <summary>
        /// 本地路径或服务器连接
        /// </summary>
        public string Path { get; set; }
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
    }
}
