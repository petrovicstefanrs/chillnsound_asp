using ChillNSound.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChillNSound
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LogedIn"] != null && Session["IdUser"] != null)
            {
                string admin_nav = "<span><a href=\"Soundboard.aspx\">Home</a></span><span><a href=\"About.aspx\">About Me</a></span><span><a href=\"Contact.aspx\">Contact</a></span><span><a href=\"ManageSounds.aspx\">Manage Sounds</a></span><span><a href=\"ManageUsers.aspx\">Manage Users</a></span><span><a href=\"ManageAbout.aspx\">Manage About</a></span><span><a href=\"Logout.aspx\">Logout</a></span>";
                footer_links.InnerHtml = admin_nav;
            }
            else
            {
                string nav = "<span><a href=\"About.aspx\">About Me</a></span><span><a href=\"Contact.aspx\">Contact</a></span><span><a href=\"Login.aspx\">Login</a></span>";
                footer_links.InnerHtml = nav;
            }

            MasterAdmin master = this.Master as MasterAdmin;
            master.setHeading("About Me");
            master.setDesc("Woot, wooot, wot, wwoooooooooooooot!");

            OperationAboutSelect op = new OperationAboutSelect();
            OperationResult res = OperationManager.Singleton.executeOperation(op);
            if ((res == null) || (!res.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = res.DbItems;
                AboutOperation[] abouts = items.Cast<AboutOperation>().ToArray();

                String html_about = "";
                foreach (AboutOperation item in abouts)
                {
                    html_about += "<img src=\"" + item.AboutImg.ToString() + "\"><h1>" + item.AboutName.ToString() + "</h1><p>"+item.AboutDesc.ToString()+"</p>";
                }
                aboutme.InnerHtml = html_about;
            }
        }
    }
}