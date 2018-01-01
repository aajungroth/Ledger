using System;
using Microsoft.EntityFrameworkCore;
namespace Ledger.Models
{
    public class LedgerContext : DbContext
    {
        public LedgerContext(DbContextOptions<LedgerContext> options)
            : base(options)
        {
        }

        public DbSet<Ledger.Models.AuthorClass> Author { get; set; }
        public DbSet<Ledger.Models.BookClass> Book { get; set; }
        public DbSet<Ledger.Models.ReviewClass> Reveiw { get; set; }
    }
}
