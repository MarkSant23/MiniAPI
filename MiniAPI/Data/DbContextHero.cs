using Microsoft.EntityFrameworkCore;

namespace MiniAPI.Data
{
    public class DbContextHero : DbContext
    {
        public DbContextHero(DbContextOptions<DbContextHero> options) : base(options)
        {

        }

        public virtual DbSet<SuperHero> superheroes { get; set; }
        public virtual DbSet<Branch> branchs{ get; set; }
    }
}
