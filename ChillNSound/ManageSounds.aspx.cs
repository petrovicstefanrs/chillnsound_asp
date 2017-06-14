using ChillNSound.BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChillNSound
{
    public partial class ManageSounds : System.Web.UI.Page
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
            master.setHeading("Manage Sounds");
            master.setDesc("Use controls below to add new sounds or edit exising.");
            
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
            string uploadFolder = Server.MapPath("images/");
            FileUpload newImage = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUploadEditImage");
            Image oldImage = (Image)GridView1.Rows[e.RowIndex].FindControl("SoundImage");
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

                e.NewValues["ImgUrl"] = "images/" + changedName;
            }
            else
            {
                e.NewValues["ImgUrl"] = oldImage.ImageUrl;
            }

            string uploadSoundFolder = Server.MapPath("sounds/");
            FileUpload newSound = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUploadEditSound");
            TextBox oldSound = (TextBox)GridView1.Rows[e.RowIndex].FindControl("SoundUrl");
            if (newSound != null && newSound.HasFile)
            {
                string oldUrl = oldSound.Text;
                FileInfo fi = new FileInfo(Server.MapPath(oldUrl));
                if (fi.Exists)
                {
                    File.Delete(Server.MapPath(oldUrl));
                }
                string fileName = newSound.PostedFile.FileName;
                string changedName = String.Format("{0}_{1}", DateTime.Now.ToString("ddMMyyyy"), fileName);
                newSound.SaveAs(Server.MapPath("sounds/" + changedName));

                e.NewValues["SoundUrl"] = "sounds/" + changedName;
            }
            else
            {
                e.NewValues["SoundUrl"] = oldSound.Text;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Image oldImage = (Image)GridView1.Rows[e.RowIndex].FindControl("SoundImage");
            string oldUrl = oldImage.ImageUrl;
            FileInfo fi = new FileInfo(Server.MapPath(oldUrl));
            if (fi.Exists)
            {
                File.Delete(Server.MapPath(oldUrl));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FileUpload newSound = FileUpload2;
            FileUpload newImage = FileUpload1;

            if ((newSound != null && newSound.HasFile) &&(newImage != null && newImage.HasFile))
            {
                string soundFileName = newSound.PostedFile.FileName;
                string soundName = String.Format("{0}_{1}", DateTime.Now.ToString("ddMMyyyy"), soundFileName);
                newSound.SaveAs(Server.MapPath("sounds/" + soundName));

                string imageFileName = newImage.PostedFile.FileName;
                string imageName = String.Format("{0}_{1}", DateTime.Now.ToString("ddMMyyyy"), imageFileName);
                newImage.SaveAs(Server.MapPath("images/" + imageName));

                OpearationSoundInsert op = new OpearationSoundInsert();
                op.Sound = new SoundOperation
                {
                    ImageUrl = "images/" + imageName,
                    SoundUrl = "sounds/" + soundName
                };
                OperationResult res = OperationManager.Singleton.executeOperation(op);
                if ((res == null) || (!res.Status))
                {
                    return;
                }
                else
                {
                    GridView1.DataBind();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "soundnew", "alert('Both image and sound are required!');", true);
            }
        }
    }
}