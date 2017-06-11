using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.sdk.svrs
{
    public class upload : _sdk
    {
        [ParmsAttr(name = "服务名称", req = true)]
        public string name { get; set; }
        [ParmsAttr(name = "上传内容", req = true)]
        public string data { get; set; }
        /// <summary>
        /// 上传类型
        /// 1、图片
        /// 2、图形
        /// 3、配置
        /// </summary>
        public int tp { get; set; }
        protected override XResp Execute()
        {
            var s = db.x_service.FirstOrDefault(o => o.name == name);
            if (s == null) throw new XExcep("T服务不存在");

            var path = Context.Server.MapPath("/svrs/" + name + "_new_" + s.service_id);

            return new XResp();
        }
    }
}
