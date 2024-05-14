using System.Data.Entity;

namespace DAL.Models
{
    internal class EContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Token> Tokens { get; set; }

    }

}
