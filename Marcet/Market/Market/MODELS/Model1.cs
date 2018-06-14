using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace Market
{
  

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Adressa> Adressas { get; set; }
        public virtual DbSet<Boss> Bosses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Count> Counts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Date_of_receipt> Date_of_receipt { get; set; }
        public virtual DbSet<FIO_Person> FIO_Person { get; set; }
        public virtual DbSet<Firm> Firms { get; set; }
        public virtual DbSet<Mark_up> Mark_up { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_category> Product_category { get; set; }
        public virtual DbSet<Product_life> Product_life { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adressa>()
                .HasMany(e => e.Firms)
                .WithMany(e => e.Adressas)
                .Map(m => m.ToTable("Adressa_link").MapLeftKey("AdressaID").MapRightKey("FirmID"));

            modelBuilder.Entity<Boss>()
                .HasMany(e => e.Firms)
                .WithMany(e => e.Bosses)
                .Map(m => m.ToTable("Вoss_link").MapLeftKey("BossID").MapRightKey("FirmID"));

            modelBuilder.Entity<City>()
                .HasMany(e => e.Firms)
                .WithMany(e => e.Cities)
                .Map(m => m.ToTable("City_link").MapLeftKey("CityID").MapRightKey("FirmID"));

            modelBuilder.Entity<Count>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Counts)
                .Map(m => m.ToTable("Count_link").MapLeftKey("Count_ProductID").MapRightKey("ProductID"));

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Firms)
                .WithMany(e => e.Countries)
                .Map(m => m.ToTable("Country_link").MapLeftKey("CountryID").MapRightKey("FirmID"));

            modelBuilder.Entity<Date_of_receipt>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Date_of_receipt)
                .Map(m => m.ToTable("Date_of_receipt_link").MapLeftKey("Date_receiptID").MapRightKey("ProductID"));

            modelBuilder.Entity<FIO_Person>()
                .HasMany(e => e.Products)
                .WithMany(e => e.FIO_Person)
                .Map(m => m.ToTable("Fio_link").MapLeftKey("FioID").MapRightKey("ProductID"));

            modelBuilder.Entity<Firm>()
                .HasMany(e => e.Phones)
                .WithRequired(e => e.Firm)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Firm>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Firm)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mark_up>()
                .Property(e => e.Count)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Mark_up>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Mark_up)
                .Map(m => m.ToTable("Mark_up_link").MapLeftKey("Mark_up").MapRightKey("ProductID"));

            modelBuilder.Entity<Price>()
                .Property(e => e.Price1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Prices)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_category)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("Product_category_link").MapLeftKey("ProductID").MapRightKey("CategoryID"));

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_life)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("Product_life_link").MapLeftKey("ProductID").MapRightKey("DateID"));
        }
    }
}
