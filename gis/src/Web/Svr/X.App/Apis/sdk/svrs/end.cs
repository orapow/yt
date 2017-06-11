using System.IO;
using System.Linq;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.sdk.svrs
{
    public class end : _sdk
    {
        [ParmsAttr(name = "服务名称", req = true)]
        public string name { get; set; }
        protected override XResp Execute()
        {
            var s = db.x_service.FirstOrDefault(o => o.name == name);
            if (s == null) throw new XExcep("T服务不存在");

            s.status = 1;
            db.SubmitDBChanges();

            try
            {
                var path = Context.Server.MapPath("/svrs/" + name);
                if (Directory.Exists(path + "_old_" + s.service_id)) Directory.Delete(path + "_old_" + s.service_id);
                if (Directory.Exists(path + "_new_" + s.service_id)) Directory.Delete(path + "_new_" + s.service_id);
                if (Directory.Exists(path + "_new_" + s.service_id + "/图形")) Directory.Delete(path + "_new_" + s.service_id + "/图形");
                if (Directory.Exists(path + "_new_" + s.service_id + "/图像")) Directory.Delete(path + "_new_" + s.service_id + "/图像");
            }
            catch { }

            return new XResp();
        }
    }
}
