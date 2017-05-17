using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views
{
    public class layer : xview
    {
        protected override string GetParmNames
        {
            get
            {
                return "gid";
            }
        }
    }
}
