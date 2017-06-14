using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChillNSound
{
    public partial class ManageAbout : System.Web.UI.Page
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
            master.setHeading("Manage About Page");
            master.setDesc("Use controls below edit info on about page.");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string uploadFolder = Server.MapPath("images/");
            FileUpload newImage = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUploadEditImage");
            Image oldImage = (Image)GridView1.Rows[e.RowIndex].FindControl("AboutImage");
            if (newImage != null && newImage.HasFile)
            {
                string oldUrl = oldImage.ImageUrl;
                FileInfo fi = new FileInfo(Server.MapPath(oldUrl));
                if (fi.Exists)
                {
                    File.Delete(Server.MapPath(oldUrl));
                }
                string fileName = newImage.PostedFile.FileName;
                string changedName = String.Format("{0}_{1}", DateTime.Now.ToString("ddMMyyyy"), fileName);
                newImage.SaveAs(Server.MapPath("images/" + changedName));

                e.NewValues["AboutImg"] = "images/" + changedName;
            }
            else
            {
                e.NewValues["AboutImg"] = oldImage.ImageUrl;
            }

            /* Update Desc */

            TextBox tbNewDesc = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox2");
            e.NewValues["AboutDesc"] = tbNewDesc.Text;

            /* Update Name */

            TextBox tbNewName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox3");
            e.NewValues["AboutName"] = tbNewName.Text;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}