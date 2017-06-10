using System.Data.Linq;
using X.App.Com;
using X.Web.Apis;

namespace X.App.Apis
{
    public class xapi : Api
    {
        protected Config cfg = null;
        protected DBDataContext db = null;
        protected override void InitApi()
        {
            base.InitApi();
            cfg = Config.LoadConfig();
            db = new DBDataContext() { DeferredLoadingEnabled = true };
        }
    }
}
