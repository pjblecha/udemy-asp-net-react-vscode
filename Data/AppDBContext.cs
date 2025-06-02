using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal sealed class AppDBContext : DbContext
    {
        private readonly string CONN_STR = @"Data Source=" + Environment.CurrentDirectory + "/Data/AppDB.db";
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlite(CONN_STR);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(SEED_POSTS);
        } 

        private readonly List<Post> SEED_POSTS =
        [
            new() { PostID = 1, Title = "First Post", Content = "This is the content for the first post. Kinda cool eh?" },
            new() { PostID = 2, Title = "Post 2", Content = "Well, this is awkward... not sure what to do." },
            new() { PostID = 3, Title = "Poste Drei", Content = "Der Post ist eine kleine Scheisse Post" },
            new() { PostID = 4, Title = "Un Post Quatre", Content = "Merde! En Francais d'accord?" },
            new() { PostID = 5, Title = "A fifth of Post", Content = "So... Beethoven or Liquor?" },
            new() { PostID = 6, Title = "Six", Content = "The number of sick sheep in a bad tongue twister" }
        ]; 
    }
}