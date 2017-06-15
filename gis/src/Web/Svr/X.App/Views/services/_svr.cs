using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.App.Com;

namespace X.App.Views.services
{
    public class _svr : xview
    {
        public string sn { get; set; }
        protected x_service svr = null;
        protected override void InitView()
        {
            base.InitView();
            if (!string.IsNullOrEmpty(sn)) svr = db.x_service.FirstOrDefault(o => o.name == sn);
        }
    }
}
