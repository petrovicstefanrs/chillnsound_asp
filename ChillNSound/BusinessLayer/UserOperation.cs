using ChillNSound.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillNSound.BusinessLayer
{
    public class UserOperation : DbItem
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return "Selected User";
        }
    }

    public class UserCriterium : QueryCriterium
    {
        private int? idUser;

        public int? IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }
        public string Username { get; set; }
        public string Password { get; set; }

    }

    public abstract class OperationUserBase : Operation
    {
        public UserCriterium Criterium { get; set; }
        public override OperationResult execute(SoundboardDBEntities entities)
        {
            IEnumerable<UserOperation> ieUsers;
            if ((this.Criterium == null) || ((this.Criterium.Username == null) && (this.Criterium.Password == null) && (this.Criterium.IdUser == null)))
            {
                ieUsers =  from user in entities.Users
                           select new UserOperation
                           {
                               IdUser = user.Id,
                               Username = user.Username,
                               Password = user.Password
                           };
            }
            else
            {
                ieUsers =  from user in entities.Users
                           where ((this.Criterium.Username == null) ? true : this.Criterium.Username == user.Username) &&
                           ((this.Criterium.Password == null) ? true : this.Criterium.Password == user.Password) &&
                           ((this.Criterium.IdUser == null) ? true : this.Criterium.IdUser < user.Id)
                           select new UserOperation
                           {
                               IdUser = user.Id,
                               Username = user.Username,
                               Password = user.Password
                           };
            }

            UserOperation[] arrUsers = ieUsers.ToArray();

            OperationResult opRes = new OperationResult();
            opRes.Message = "All Users Fetched";
            opRes.Status = true;
            opRes.DbItems = arrUsers;
            return opRes;
        }
    }

    public class OperationUserSelect : OperationUserBase
    {

    }

    public class OpearationUserUpdate : OperationUserBase
    {
        private UserOperation user;

        public UserOperation User
        {
            get { return user; }
            set { user = value; }
        }

        public override OperationResult execute(SoundboardDBEntities entities)
        {
            if ((this.User != null) && (this.User.IdUser > 0) &&
                !string.IsNullOrEmpty(this.User.Username) &&
                !string.IsNullOrEmpty(this.User.Password))
            {
                entities.UserUpdate(this.User.IdUser, this.User.Username, this.User.Password);
            }
            return base.execute(entities);
        }
    }

    public class OpearationUserDelete : OperationUserBase
    {
        private UserOperation user;

        public UserOperation User
        {
            get { return user; }
            set { user = value; }
        }

        public override OperationResult execute(SoundboardDBEntities entities)
        {
            if ((this.User != null) && (this.User.IdUser > 0))
            {
                entities.DeleteUser(this.User.IdUser);
            }
            return base.execute(entities);
        }
    }

    public class OpearationUserInsert : OperationUserBase
    {
        private UserOperation user;

        public UserOperation User
        {
            get { return user; }
            set { user = value; }
        }

        public override OperationResult execute(SoundboardDBEntities entities)
        {
            if ((this.User != null) &&
                !string.IsNullOrEmpty(this.User.Username) &&
                !string.IsNullOrEmpty(this.User.Password))
            {
                entities.UserInsert(this.User.Username, this.User.Password);
            }
            return base.execute(entities);
        }
    }
}
