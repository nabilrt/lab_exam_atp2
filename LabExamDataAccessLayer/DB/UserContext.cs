using LabExamDataAccessLayer.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamDataAccessLayer.DB
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Token> Tokens { get; set; }
    }
}
