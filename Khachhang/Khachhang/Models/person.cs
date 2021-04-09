using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Khachhang.Models
{
    [Table("persons")]
    public class person
    {
        [Key]
        public string CCCD { get; set; }
        public string Fullname { get; set; }
    }
}