using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ado_hw_15
{
    public class OlympiadContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<TypeOfSport> TypeOfSports { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Olympiad> Olimpiads { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<ResultParticipant> ResultParticipants { get; set; }
        public OlympiadContext(DbContextOptions<OlympiadContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Olympiad>().HasIndex(o => o.Year).IsUnique().IsClustered();
        }
    }
}
