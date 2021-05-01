using System.Data.Entity;

namespace DALSageBookDB
{
    public class SageBookContext : DbContext
    {
        public SageBookContext(string conStr) : base(conStr)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Book
            modelBuilder.Entity<Book>().Property(x => x.Title)
                .HasColumnType("nvarchar")
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Book>().Property(x => x.Pages).IsRequired();
            #endregion

            #region Sage

            modelBuilder.Entity<Sage>().Property(x=>x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Sage>().Property(x => x.Age).IsRequired();

            #endregion
            modelBuilder.Entity<Sage>()
                .HasMany(x => x.Books)
                .WithMany(x => x.Sages);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Sage> Sages { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SageBook> SageBooks { get; set; }

    }
}
