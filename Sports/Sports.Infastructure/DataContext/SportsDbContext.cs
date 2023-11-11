using Microsoft.EntityFrameworkCore;
using Sports.Domain.Entities;


namespace Sports.Infastructure.DataContext
{
    public class SportsDbContext:DbContext
    {
        public SportsDbContext(DbContextOptions<SportsDbContext> options):base(options) { }
        public virtual DbSet<Team> Teams  { get; set; }
        public virtual DbSet<Player> Players  { get; set; }
        public virtual DbSet<Tournament> Tournaments  { get; set; }
        public virtual DbSet<TeamTournament> TeamTournaments  { get; set; }
        public virtual DbSet<Match> Matches  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamTournament>().HasKey(x => new { x.TournamentId, x.TeamId });
            base.OnModelCreating(modelBuilder);
        }

    }
}
