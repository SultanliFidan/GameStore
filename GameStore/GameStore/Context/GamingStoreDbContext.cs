using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Context;


public class GamingStoreDbContext : DbContext
{
    public GamingStoreDbContext(DbContextOptions<GamingStoreDbContext> options) : base(options) { }

    public DbSet<Game> Games { get; set; }
}
