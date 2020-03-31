using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Coursat.Models
{
    public class USER : WEBSITE_USER
    {
        [Required]
        [StringLength(20)]
        public String User_name { get; set; }

        //Addtional attributes not used in database table
        [NotMapped]
        public String RepeatPass { get; set; }
        
    }
}