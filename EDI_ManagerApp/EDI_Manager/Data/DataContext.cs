using EDI_Manager.TableDefinitions;
using Microsoft.EntityFrameworkCore;

namespace EDI_Manager.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<SSHKey> SSHKeys { get; set; }
        public DbSet<FTPAccount> FTPAccounts { get; set; }

    }
}
