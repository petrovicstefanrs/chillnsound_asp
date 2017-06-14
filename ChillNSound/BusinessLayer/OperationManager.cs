using ChillNSound.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillNSound.BusinessLayer
{
    public class OperationManager
    {
        private OperationManager()
        {

        }
        private static volatile OperationManager singleton;

        private static object lockObj = new object();

        public static OperationManager Singleton
        {
            get 
            {
                if (OperationManager.singleton == null)
                {
                    lock (OperationManager.lockObj)
                    {
                        if (OperationManager.singleton == null)
                        {
                            OperationManager.singleton = new OperationManager();
                        }
                    }
                }
                return OperationManager.singleton;
            }
        }

        private SoundboardDBEntities entities = new SoundboardDBEntities();

        public OperationResult executeOperation(Operation op)
        {
            try
            {
                return op.execute(this.entities);
            }
            catch(Exception e) {
                OperationResult opRes = new OperationResult();
                opRes.Status = false;
                opRes.Message = "Something went wrong.";
                return opRes;
            }
        }

    }
}
