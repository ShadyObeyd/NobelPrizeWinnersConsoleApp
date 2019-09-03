namespace NobelPrizeWinners.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models.DataModels;

    public class NobelPrizeWinnersDbContext : DbContext
    {
        public NobelPrizeWinnersDbContext()
        {

        }

        public NobelPrizeWinnersDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<NobelPrizeWinner> NobelPrizeWinners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
