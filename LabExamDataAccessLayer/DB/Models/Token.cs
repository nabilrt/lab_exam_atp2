﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamDataAccessLayer.DB.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }

        public string TokenDetails { get; set; }

        public DateTime Creation_Time { get; set; }

        public DateTime? Expired_At { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
