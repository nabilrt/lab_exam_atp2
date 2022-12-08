using LabExamDataAccessLayer.DB.Models;
using LabExamDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamDataAccessLayer.Operations
{
    internal class UserOperations : Operations,IOperations<User, int, bool,string>,IAuth<User>
    {
        public User Add(User cls)
        {
            var user=db.Users.Add(cls);
            db.SaveChanges();
            return user;
        }

        public bool Delete(int id)
        {
            db.Users.Remove(get(id));

            return db.SaveChanges()>0;
        }

        public User get(int id)
        {
            return db.Users.Find(id);
        }


        public List<User> getALL()
        {
           return db.Users.ToList();
        }

        public User Login(string username,string password)
        {
            var user= db.Users.FirstOrDefault(x => x.Uname.Equals(username) && x.Password.Equals(password));

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public bool Update(User cls)
        {
            var user = get(cls.Id);

            if(user != null) { 
            
                user.Uname = cls.Uname;
                user.Password = cls.Password;
                user.Type = cls.Type;
               
                return db.SaveChanges() > 0;
            }

            return false;
        }
    }
}
