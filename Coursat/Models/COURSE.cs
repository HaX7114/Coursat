using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coursat.Models
{
    public class COURSE
    {
        [Key]
        public int Course_ID { get; set; }
        [Required]
        [StringLength(50)]
        public String Course_Name { get; set; }
        
        public int Course_Hours { get; set; }
        
        public int Course_Min { get; set; }
        [Required]
        [StringLength(20)]
        public String Course_Day { get; set; }
        [Required]
        [StringLength(50)]
        public String Course_Place { get; set; }

        public int Max_Students_Number { get; set; }

    }
}