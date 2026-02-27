using System;
using Microsoft.EntityFrameworkCore;
using PaintStore.Models;

namespace PaintStore.API.DataAccess;

public class PaintStoreDbContext : DbContext
{
    public DbSet<PaintProduct> PaintProducts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }

    public PaintStoreDbContext(DbContextOptions<PaintStoreDbContext> options):base(options)
    {      
    }
}
