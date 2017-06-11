using System;
using System.IO;
using System.Linq;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.sdk.svrs
{
    public class status : _sdk
    {
        [ParmsAttr(name = "服务名称", req = true)]
        public string name { get; set; }
        /// <summary>
        /// 1、覆盖模式
        /// </summary>
        public int isover { get; set; }
        protected override XResp Execute()
        {
            var s = db.x_service.FirstOrDefault(o => o.name == name);
            if (s == null) throw new XExcep("T服务不存在");

            s.status = 2;

            var path = Context.Server.MapPath("/svrs/" + name);
            if (isover == 1)
            {
                s.x_block.Clear();
                s.x_layer.Clear();
                s.x_grid.Clear();
                try
                {
                    Directory.Move(path, path + "_old_" + s.service_id);
                }
                catch (Exception e) { throw new XExcep("T服务覆盖失败，错误信息：", e.Message); }
            }
            try
            {
                Directory.CreateDirectory(path + "_new_" + s.service_id);
                Directory.CreateDirectory(path + "_new_" + s.service_id + "/图像");
                Directory.CreateDirectory(path + "_new_" + s.service_id + "/图形");
            }
            catch (Exception e) { throw new XExcep("T服务创建失败，错误信息：" + e.Message); }

            db.SubmitDBChanges();

            return new XResp();
        }
    }
}
