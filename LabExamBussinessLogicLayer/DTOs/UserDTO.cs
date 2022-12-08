using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamBussinessLogicLayer.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string Uname { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
