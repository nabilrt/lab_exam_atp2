using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamDataAccessLayer.DB.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Uname { get; set; }

        public string Password { get; set; }

        public string Type { get; set; }

        public virtual List<Token> Tokens { get; set; }

        public User() { 
            Tokens = new List<Token>();
        }
    }
}
