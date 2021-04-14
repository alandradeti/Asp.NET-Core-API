using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilContext : DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base (options){}

        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> speakerEvents { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Lot> Lots { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerEvent>()
                .HasKey(SE => new {SE.EventId, SE.SpeakerId});
        }

    }
}