using ChillNSound.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillNSound.BusinessLayer
{
    public abstract class Operation
    {
        public abstract OperationResult execute(SoundboardDBEntities entities);
    }

    public class OperationResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public DbItem[] DbItems { get; set; } 
    }

    public abstract class DbItem{

    }

    public abstract class QueryCriterium
    {

    }
}
