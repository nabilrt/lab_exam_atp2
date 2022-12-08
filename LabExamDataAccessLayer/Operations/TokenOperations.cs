using LabExamDataAccessLayer.DB.Models;
using LabExamDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamDataAccessLayer.Operations
{
    internal class TokenOperations : Operations, IOperations<Token, string, bool,string>
    {
        public Token Add(Token cls)
        {
            var token=db.Tokens.Add(cls);
            db.SaveChanges();
            return token;
        }

        public bool Delete(string id)
        {
            //var user = db.Tokens.Find(id);
            db.Tokens.Remove(get(id));

            return db.SaveChanges()>0;
        }

      
        public Token get(string id)
        {
            return (from tk in db.Tokens where tk.TokenDetails == id select tk).FirstOrDefault();
        }

        public List<Token> getALL()
        {
            return db.Tokens.ToList();
        }

        public bool Update(Token cls)
        {
            var user = db.Tokens.Find(cls.Id);

            var token = get(user.TokenDetails);

            if (token != null)
            {
                token.TokenDetails = cls.TokenDetails;
                token.UserId = cls.UserId;  
                token.Creation_Time = cls.Creation_Time;
                token.Expired_At=DateTime.Now;

                return db.SaveChanges() > 0;
            }

            return false;
        }
    }
}
