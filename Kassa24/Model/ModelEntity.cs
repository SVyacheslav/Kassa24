namespace Kassa24.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelEntity : DbContext
    {
        public ModelEntity()
            : base("name=ModelEntity")
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Table_Operator> Table_Operator { get; set; }
        public virtual DbSet<Table_Prefix> Table_Prefix { get; set; }
        public virtual DbSet<Table_Payments> Table_Payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
