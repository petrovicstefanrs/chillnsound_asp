using ChillNSound.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChillNSound
{
    public partial class Soundboard : System.Web.UI.Page
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

            OperationSoundSelect op = new OperationSoundSelect();
            OperationResult res = OperationManager.Singleton.executeOperation(op);
            if ((res == null) || (!res.Status))
            {
                return;
            }
            else
            {
                DbItem[] items = res.DbItems;
                SoundOperation[] sounds = items.Cast<SoundOperation>().ToArray();

                String html_sounds = "";
                foreach (SoundOperation sound in sounds)
                {
                    html_sounds +="<div class='sound_block'><audio><source src=\"" + sound.SoundUrl.ToString() + "\"/></audio><div class='start_btn'><img src=\"" + sound.ImageUrl.ToString() + "\"><a class='play' href='#!'></a></div><input class='volume_bar' type='range' value='0' max='1' step='0.001' /></div>";
                }
                sounds_container.InnerHtml = html_sounds;
            }
        }
    }
}