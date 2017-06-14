using ChillNSound.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChillNSound
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LogedIn"] == null || Session["IdUser"] == null)
            {
                Response.Redirect("~/Soundboard.aspx");
            }

            string admin_nav = "<span><a href=\"Soundboard.aspx\">Home</a></span><span><a href=\"About.aspx\">About Me</a></span><span><a href=\"Contact.aspx\">Contact</a></span><span><a href=\"ManageSounds.aspx\">Manage Sounds</a></span><span><a href=\"ManageUsers.aspx\">Manage Users</a></span><span><a href=\"ManageAbout.aspx\">Manage About</a></span><span><a href=\"Logout.aspx\">Logout</a></span>";
            footer_links.InnerHtml = admin_nav;

            MasterAdmin master = this.Master as MasterAdmin;
            master.setHeading("Manage Authorized Users");
            master.setDesc("Use controls below to control authorized users.");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string newUserUsername = tbNewUsername.Text;
            string newUserPass = tbNewPassword.Text;

            if ((newUserUsername.Length > 5) && (newUserPass.Length > 5))
            {
                OpearationUserInsert op = new OpearationUserInsert();
                op.User = new UserOperation
                {
                    Username = newUserUsername,
                    Password = newUserPass
                };
                OperationResult res = OperationManager.Singleton.executeOperation(op);
                if ((res == null) || (!res.Status))
                {
                    return;
                }
                else
                {
                    tbNewPassword.Text = "";
                    tbNewUsername.Text = "";
                    GridView1.DataBind();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "pass", "alert('Username and Password must be longer than 5 characters!');", true);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            /* Update Username */

            TextBox tbUser = (TextBox)GridView1.Rows[e.RowIndex].FindControl("tbUsernameEdit");
            e.NewValues["Username"] = tbUser.Text;

            /* Update Pass */

            TextBox tbPass = (TextBox)GridView1.Rows[e.RowIndex].FindControl("tbPassEdit");
            e.NewValues["Password"] = tbPass.Text;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}