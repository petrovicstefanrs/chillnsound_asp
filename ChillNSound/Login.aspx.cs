using ChillNSound.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChillNSound
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LogedIn"] != null && Session["IdUser"] != null)
            {
                Response.Redirect("~/ManageSounds.aspx");
            }
            else
            {
                string nav = "<span><a href=\"About.aspx\">About Me</a></span><span><a href=\"Contact.aspx\">Contact</a></span><span><a href=\"Login.aspx\">Login</a></span>";
                footer_links.InnerHtml = nav;
            }
            MasterAdmin master = this.Master as MasterAdmin;
            master.setHeading("Log In");
            master.setDesc("Use your authorizaton credentials to access the Admin Panel.");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Value;
            string password = tbPassword.Value;
            OperationUserSelect op = new OperationUserSelect();
            op.Criterium = new UserCriterium
            {
                Password = password,
                Username = username
            };
            OperationResult res = OperationManager.Singleton.executeOperation(op);
            if ((res == null) || (!res.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = res.DbItems;
                UserOperation[] users = items.Cast<UserOperation>().ToArray();
                

                foreach (UserOperation user in users)
                {
                    Session["LogedIn"] = true;
                    Session["IdUser"] = user.IdUser;
                }
                if (Session["LogedIn"] != null && Session["IdUser"] != null)
                {
                    Response.Redirect("~/ManageSounds.aspx");
                }
            }
        }
    }
}