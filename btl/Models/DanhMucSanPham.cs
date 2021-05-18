using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace btl.Models
{
    [Table("DanhMucSanPhams")]
    public class DanhMucSanPham
    {
        [Key]
        public int MaSanPham { get; set; }
        [AllowHtml]
        public string TenSanPham { get; set; }
        public int Tongsoluongbandau { get; set; }
        public int SoLuongDaBan { get; set; }
        public int SoLuongConLai { get; set; }
    }
}