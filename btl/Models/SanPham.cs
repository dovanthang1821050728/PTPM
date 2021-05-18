using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace btl.Models
{
   [Table("SanPhams")]
    public class SanPham
    {
        [Key]
        public int IDsp { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string GiaBan { get; set; }
        public string SoLuongTrongKho { get; set; }
        public string SoLuongDaBan { get; set; }
        public string SoLuongConLai { get; set; }
    }
}