using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace btl.Models
{
    [Table("ThongTinKhachhangs")]
    public class ThongTinKhachhang
    {
        [Key]
        public int ID { get; set; }
        public string TenKhachHang { get; set; }
        [AllowHtml]
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
    }
}