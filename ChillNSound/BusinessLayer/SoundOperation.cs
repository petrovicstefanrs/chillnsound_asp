using ChillNSound.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillNSound.BusinessLayer
{
    public class SoundOperation : DbItem
    {
        public int IdSound { get; set; }
        public string SoundUrl { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return "Selected Sound";
        }
    }

    public class SoundCriterium : QueryCriterium{
        private int? idSound;

        public int? IdSound
        {
            get { return IdSound; }
            set { IdSound = value; }
        }
        public string SoundUrl { get; set; }
        public string ImageUrl { get; set; }
        
    }

    public abstract class OperationSoundBase : Operation
    {
        public SoundCriterium Criterium { get; set; }
        public override OperationResult execute(SoundboardDBEntities entities)
        {
            IEnumerable<SoundOperation> ieSounds;
            if ((this.Criterium == null) || ((this.Criterium.SoundUrl == null) && (this.Criterium.ImageUrl == null) && (this.Criterium.IdSound == null)))
            {
                ieSounds = from sound in entities.Sounds
                            select new SoundOperation
                            {
                                IdSound = sound.Id,
                                SoundUrl = sound.SoundUrl,
                                ImageUrl = sound.ImgUrl
                            };
            }
            else
            {
                ieSounds = from sound in entities.Sounds
                            where ((this.Criterium.SoundUrl == null) ? true : this.Criterium.SoundUrl == sound.SoundUrl) &&
                            ((this.Criterium.ImageUrl == null) ? true : this.Criterium.ImageUrl == sound.ImgUrl) && 
                            ((this.Criterium.IdSound == null)? true : this.Criterium.IdSound<sound.Id)
                            select new SoundOperation
                            {
                                IdSound = sound.Id,
                                SoundUrl = sound.SoundUrl,
                                ImageUrl = sound.ImgUrl
                            };
            }

            SoundOperation[] arrSounds = ieSounds.ToArray();

            OperationResult opRes = new OperationResult();
            opRes.Message = "All Sounds Fetched";
            opRes.Status = true;
            opRes.DbItems = arrSounds;
            return opRes;
        }
    }

    public class OperationSoundSelect : OperationSoundBase
    {

    }

    public class OpearationSoundUpdate : OperationSoundBase
    {
        private SoundOperation sound;

        public SoundOperation Sound
        {
            get { return sound; }
            set { sound = value; }
        }

        public override OperationResult execute(SoundboardDBEntities entities)
        {
            if ((this.Sound != null) && (this.Sound.IdSound > 0) &&
                !string.IsNullOrEmpty(this.Sound.SoundUrl) &&
                !string.IsNullOrEmpty(this.Sound.ImageUrl))
            {
                entities.SoundUpdate(this.Sound.IdSound, this.Sound.SoundUrl, this.Sound.ImageUrl);
            }
            return base.execute(entities);
        }
    }

    public class OpearationSoundDelete : OperationSoundBase
    {
        private SoundOperation sound;

        public SoundOperation Sound
        {
            get { return sound; }
            set { sound = value; }
        }

        public override OperationResult execute(SoundboardDBEntities entities)
        {
            if ((this.Sound != null) && (this.Sound.IdSound > 0))
            {
                entities.SoundDelete(this.Sound.IdSound);
            }
            return base.execute(entities);
        }
    }

    public class OpearationSoundInsert : OperationSoundBase
    {
        private SoundOperation sound;

        public SoundOperation Sound
        {
            get { return sound; }
            set { sound = value; }
        }

        public override OperationResult execute(SoundboardDBEntities entities)
        {
            if((this.Sound != null) && 
                !string.IsNullOrEmpty(this.Sound.SoundUrl) &&
                !string.IsNullOrEmpty(this.Sound.ImageUrl))
            {
                entities.SoundInsert(this.Sound.SoundUrl, this.Sound.ImageUrl);
            }
            return base.execute(entities);
        }
    }
}
