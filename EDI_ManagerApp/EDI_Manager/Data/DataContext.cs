using EDI_Manager.TableDefinitions;
using EDI_Manager.Utilities;
using Microsoft.EntityFrameworkCore;

namespace EDI_Manager.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Election>().HasKey(table => new {
                table.ElectionId,
                table.SourceFilePath
            });
        }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FileMime> FileMimes { get; set; }
        public DbSet<SSHKey> SSHKeys { get; set; }
        public DbSet<FTPAccount> FTPAccounts { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<CarrierType> CarrierTypes { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<FeedFrequency> FeedFrequency { get; set; }
        public DbSet<FeedSecurityType> FeedSecurityType { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Spouse> Spouses { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Election> Elections { get; set; }
    }
}
