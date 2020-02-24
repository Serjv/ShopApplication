using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopApplication.Models
{
    public class Consultants
    {
        [Key]
        public int ConsultantID { get; set; }
        [Required]
        public string ConsultantName { get; set; }
        [Required]
        public string ConsultantSurname { get; set; }
        
        
        public virtual ICollection<Interconnections> Interconnections { get; set; }

    }
}