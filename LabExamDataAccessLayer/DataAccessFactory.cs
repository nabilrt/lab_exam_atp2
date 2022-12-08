using LabExamDataAccessLayer.DB.Models;
using LabExamDataAccessLayer.Interfaces;
using LabExamDataAccessLayer.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamDataAccessLayer
{
    public class DataAccessFactory
    {
        public static IOperations<User,int,bool,string> UserDataAccess()
        {
            return new UserOperations();
        }

        public static IOperations<Token, string, bool, string> TokenDataAccess()
        {
            return new TokenOperations();
        }

        public static IAuth<User> LoginDataAccess()
        {
            return new UserOperations();
        }
    }
}
