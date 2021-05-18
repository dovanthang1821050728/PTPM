using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace btl.Models
{
    public class Account
    {
        [Key]
        [Required(ErrorMessage = "User name is required.")]
        public string TenDangNhap { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}