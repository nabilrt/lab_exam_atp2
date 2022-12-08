using LabExamDataAccessLayer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamDataAccessLayer.Operations
{
    internal class Operations
    {
        protected UserContext db;

        public Operations()
        {
            db = new UserContext();
        }
    }
}
