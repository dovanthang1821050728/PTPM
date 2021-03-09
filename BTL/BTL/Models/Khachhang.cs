using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTL.Models
{   
    [Table]
    public class Khachhang
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
    }
}