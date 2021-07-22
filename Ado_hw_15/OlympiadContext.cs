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
        public OlympiadContext(DbContextOptions<OlympiadContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
    }
}
