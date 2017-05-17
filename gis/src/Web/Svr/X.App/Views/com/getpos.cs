using X.Core.Utility;

namespace X.App.Views.com
{
    public class getpos : xview
    {
        protected override string GetParmNames
        {
            get { return "key-point"; }
        }

        protected override void InitDict()
        {
            base.InitDict();
            var point = dict.GetString("point");
            if (!string.IsNullOrEmpty(point)) point = Secret.FormBase64(point);
            dict.Update("point", point);
        }
    }
}
