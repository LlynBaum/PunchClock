using Microsoft.EntityFrameworkCore;

namespace M223PunchclockDotnet.Model {

    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<Entry> Entries {get; set;}
        
        public DbSet<Tag> Tags {get; set;}
        
        public DbSet<Category> Categories {get; set;}
        
        public DbSet<User> Users {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Entry>().ToTable("Entry");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<Category>().ToTable("Category");
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseNpgsql("Host=db;Database=postgres;Username=postgres;Password=postgres");
    }
}