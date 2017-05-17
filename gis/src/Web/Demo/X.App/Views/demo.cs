using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views
{
    public class demo : xview
    {
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("cts", cfg.cates.Split('|').ToList());
        }
    }
}
