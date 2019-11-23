using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using WestPay.Access.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using WestPay.Access.DAL.Entities.Library;
using WestPay.Access.DAL.Entities.Terminals;

namespace WestPay.Access.DAL.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBiography> Biographies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        //public DbSet<BookCategory> BookCategories { get; set; }

        public DbSet<PhysicalTerminal> PhysicalTerminals { get; set; }
        public DbSet<OperationSetting> OperationSetting { get; set; }
        public DbSet<TerminalModel> TerminalModels { get; set; }
        public DbSet<TerminalOperationMode> TerminalOperationModes { get; set; }
        public DbSet<TerminalOperationSetting> TerminalOperationSetting{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasIndex(u => u.ISBN)
                .IsUnique();

            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddTracking();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTracking();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddTracking()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is ITrackable trackable)
                {
                    var now = DateTime.UtcNow;
                    var userAndIPAddress = $"{GetCurrentUser()} /ip: {GetLocalIPAddress()}";
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.LastUpdatedAt = now;
                            trackable.LastUpdatedBy = userAndIPAddress;
                            break;

                        case EntityState.Added:
                            trackable.CreatedAt = now;
                            trackable.CreatedBy = userAndIPAddress;
                            trackable.LastUpdatedAt = now;
                            trackable.LastUpdatedBy = userAndIPAddress;
                            break;
                    }
                }
            }
        }

        private string GetCurrentUser()
        {
            var envUser = Environment.UserName;
            if (!string.IsNullOrEmpty(envUser))
            {
                return envUser;
            }

            return "Anonymous";
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
