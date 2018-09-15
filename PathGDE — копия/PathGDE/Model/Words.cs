namespace PathGDE
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Words : DbContext
    {
        public Words()
            : base("name=Words")
        {
        }

        public virtual DbSet<Prohibited_words> Prohibited_words { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
