using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rwa_projekt_katlija_2407
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            username.InnerText = Request.Cookies.Get("userData").Values[0].ToString();
        }
    }
}