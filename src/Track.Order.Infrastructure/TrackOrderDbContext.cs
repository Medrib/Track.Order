namespace Track.Order.Infrastructure;

using Track.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class TrackOrderDbContext : DbContext
{
    private const string Schema = "track_order";

    public TrackOrderDbContext(DbContextOptions<TrackOrderDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Order => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder
        .ApplyConfigurationsFromAssembly(typeof(TrackOrderDbContext).Assembly)
        .HasDefaultSchema(Schema);
}
