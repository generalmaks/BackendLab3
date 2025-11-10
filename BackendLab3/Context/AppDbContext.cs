using Microsoft.EntityFrameworkCore;

namespace BackendLab3.Context;

public partial class AppDbContext : DbContext
{
    private IConfiguration _config;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config)
        : base(options)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlite(_config.GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
