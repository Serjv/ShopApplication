using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopApplication.Models
{
    public class Interconnections
    {
        [Key]
        public int ID { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int ShopID { get; set; }
        public virtual Shops Shops { get; set; }

        [Required]
        public int ConsultantID { get; set; }
        public virtual Consultants Consultants { get; set; }
}
}