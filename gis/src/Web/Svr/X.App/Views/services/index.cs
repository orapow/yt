using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.services
{
    public class index : xview
    {
        public string dir { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "dir";
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
        }
    }
}
