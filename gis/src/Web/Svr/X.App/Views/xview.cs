using X.App.Com;
using X.Web.Views;
//using X.Data;

namespace X.App.Views
{
    public class xview : View
    {
        /// <summary>
        /// 系统配置文件
        /// </summary>
        protected Config cfg = null;
        //public DataClassesDataContext db = null;

        protected override void InitView()
        {
            base.InitView();
            cfg = Config.LoadConfig();
            //db = new DataClassesDataContext() { DeferredLoadingEnabled = true };
        }
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("cfg", cfg);
        }
    }
}
