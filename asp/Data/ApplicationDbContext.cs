using Microsoft.EntityFrameworkCore;
using asp.Models; // Add the correct using directive for the namespace where Category is defined

namespace asp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
}

