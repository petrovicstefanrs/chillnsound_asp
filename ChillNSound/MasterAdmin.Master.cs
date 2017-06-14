using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChillNSound
{
    public partial class MasterAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void setHeading(string heading)
        {
            this.naslov.InnerText = heading;
        }
        public void setDesc(string desc)
        {
            this.desc.InnerText = desc;
        }
    }
}

/*
if (Session["LogedIn"] == null)
            {
                Response.Redirect("~/Soundboard.aspx");
            } 
     
*/
