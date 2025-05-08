using Microsoft.EntityFrameworkCore;
using OAuthSystem.Data.Entities;

namespace OAuthSystem.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<ApplicationCode> ApplicationCodes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
