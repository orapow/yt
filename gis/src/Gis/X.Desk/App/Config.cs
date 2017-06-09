using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using X.Core.Utility;

namespace X.Desk
{
    public class Config
    {
        public string Key { get; set; }
        public List<Link> Links { get; set; }

        private static Config cfg = null;
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public static Config LoadConfig()
        {
            if (cfg == null)
            {
                var json = Tools.ReadFile(Application.StartupPath + "\\cfg.x");
                if (string.IsNullOrEmpty(json)) return new Config();
                cfg = Serialize.FromJson<Config>(json);
            }
            return cfg;
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="cfg"></param>
        public static void SaveConfig(Config cfg)
        {
            Tools.SaveFile(Application.StartupPath + "\\cfg.x", Serialize.ToJson(cfg));
        }

        public class Link
        {
            public string url { get; set; }
            public int status { get; set; }
            public override string ToString()
            {
                return url + " " + (status == 1 ? "正常" : "失效");
            }
        }
    }
}
