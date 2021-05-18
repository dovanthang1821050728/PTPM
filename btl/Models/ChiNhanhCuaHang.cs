using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace btl.Models
{
   
        [Table("ChiNhanhCuaHang")]
        public class ChiNhanhCuaHang
        {
            [Key]
            public int MaCuaHang { get; set; }
            [AllowHtml]
            public string TenCuaHang { get; set; }
            public int Tonghangtrongkho { get; set; }
            public int SoLuongDaBan { get; set; }
            public int SoLuongConLai { get; set; }
        }
    }
