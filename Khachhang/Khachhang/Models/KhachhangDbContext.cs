namespace Khachhang.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KhachhangDbContext : DbContext
    {
        public KhachhangDbContext()
            : base("name=KhachhangDbContext")
        {
        }

        public virtual DbSet<KH> KHs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
