using Microsoft.EntityFrameworkCore;
using api.Entities;

namespace api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> Users {get; set;}
}
