using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChillNSound
{
    public partial class Contact : System.Web.UI.Page
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
            master.setHeading("Contact Us");
            master.setDesc("If you have any questions, or just want to say hi, drop us a line or two below.");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = tbFirstName.Text;
            string mail = tbEmail.Text;
            if (this.IsValid)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Thank you, "+name+". We will contact you shortly using this email: "+mail+"');", true);
                tbFirstName.Text = "";
                tbLastName.Text = "";
                tbMessage.InnerText = "";
                tbEmail.Text = "";
            }
        }
    }
}