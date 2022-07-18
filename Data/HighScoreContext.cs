using GrpcHighscoreService.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GrpcHighscoreService.Data
{
    public class HighscoreContext : DbContext
    {
        public HighscoreContext(DbContextOptions<HighscoreContext> options) : base(options)
        {
        }

        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Score>()
                .Property(score => score.TimeCreated)
                .HasConversion(v => v,
                               v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        }
    }
}
