using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopApplication.Models
{
    public class Shops
    {
        [Key]
        public int ShopID { get; set; }
        [Required]
        public string ShopName { get; set; }
        [Required]
        public string Address { get; set; }

        public virtual ICollection<Interconnections> Interconnections { get; set; }

    }
}