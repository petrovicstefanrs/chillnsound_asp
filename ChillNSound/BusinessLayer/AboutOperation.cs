using ChillNSound.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillNSound.BusinessLayer
{
    public class AboutOperation : DbItem
    {
        public int AboutId { get; set; }
        public string AboutName { get; set; }
        public string AboutDesc { get; set; }
        public string AboutImg { get; set; }

        public override string ToString()
        {
            return "Selected About";
        }
    }

    public abstract class OperationAboutBase : Operation
    {
        public override OperationResult execute(SoundboardDBEntities entities)
        {
            IEnumerable<AboutOperation> ieAbout;
            ieAbout =  from about in entities.Abouts
                       select new AboutOperation
                       {
                           AboutId = about.Id,
                           AboutImg = about.AboutImg,
                           AboutDesc = about.AboutDesc,
                           AboutName = about.AboutName
                       };

            AboutOperation[] arrAbout = ieAbout.ToArray();

            OperationResult opRes = new OperationResult();
            opRes.Message = "All About Fetched";
            opRes.Status = true;
            opRes.DbItems = arrAbout;
            return opRes;
        }
    }

    public class OperationAboutSelect : OperationAboutBase
    {

    }

    public class OpearationAboutUpdate : OperationAboutBase
    {
        private AboutOperation about;

        public AboutOperation About
        {
            get { return about; }
            set { about = value; }
        }

        public override OperationResult execute(SoundboardDBEntities entities)
        {
            if ((this.About != null) && (this.About.AboutId > 0) &&
                !string.IsNullOrEmpty(this.About.AboutDesc) &&
                !string.IsNullOrEmpty(this.About.AboutName) &&
                !string.IsNullOrEmpty(this.About.AboutImg))
            {
                entities.UpdateAbout(this.About.AboutId,this.About.AboutImg,this.About.AboutName,this.About.AboutDesc);
            }
            return base.execute(entities);
        }
    }

}
