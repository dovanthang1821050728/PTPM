using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Khachhang.Models
{
    [Table("KHs")]
    public class KH
    {
        [Key]
        public int ID { get; set; }
        public int Name { get; set; }

        public string Address { get; set; }
        public int PhoneNumber { get; set; }

    }
}