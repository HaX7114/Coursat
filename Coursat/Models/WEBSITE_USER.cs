using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coursat.Models
{
    public class WEBSITE_USER
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public String Email { get; set; }
        [Required]
        [StringLength(50)]
        public String Password { get; set; }
    }
}