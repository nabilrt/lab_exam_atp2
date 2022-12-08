using LabExamDataAccessLayer.DB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamBussinessLogicLayer.DTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }

        [Required]
        public string TokenDetails { get; set; }

        [Required]
        public DateTime Creation_Time { get; set; }

        public DateTime? Expired_At { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
