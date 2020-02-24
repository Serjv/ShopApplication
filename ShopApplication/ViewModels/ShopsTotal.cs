using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopApplication.ViewModels
{
    public class ShopsTotal
    {
        public int ID { get; set; }
        public string ShopName { get; set; }
        public string ConsultantName { get; set; }
        public string ConsultantSurname { get; set; }
        public string Address { get; set; }
        public DateTime? Date { get; set; }
    }
}