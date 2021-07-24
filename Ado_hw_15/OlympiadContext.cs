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
            modelBuilder.Entity<CityOlympiad>().HasKey(u => new { u.CityId, u.OlympiadYear });
            modelBuilder.Entity<DisciplineParticipant>().HasKey(u => new { u.DisciplineId, u.ParticipantId });
            modelBuilder.Entity<ParticipantTypeOfSport>().HasKey(u => new { u.ParticipantId, u.TypeOfSportId });
            Country[] countries = new Country[]
            {
                new Country(){Id=1, Name="USA"},
                new Country(){Id=2, Name="Brazil"},
                new Country(){Id=3, Name="UK"},
                new Country(){Id=4, Name="German"},
                new Country(){Id=5, Name="China"}
            };
            City[] cities = new City[]
            {
                new City(){Id=1, Name="Washington"},
                new City(){Id=2, Name="Rio de Janeiro"},
                new City(){Id=3, Name="London"},
                new City(){Id=4, Name="Berlin"},
                new City(){Id=5, Name="Beijing"}
            };
            TypeOfSport[] typeOfSports = new TypeOfSport[]
            {
                new TypeOfSport(){Id=1, Name="Basketball"},
                new TypeOfSport(){Id=2, Name="Boxing"},
                new TypeOfSport(){Id=3, Name="Volleyball"},
                new TypeOfSport(){Id=4, Name="Bobsled"},
                new TypeOfSport(){Id=5, Name="Biathlon"}
            };
            Olympiad[] olympiads = new Olympiad[]
            {
                new Olympiad(){Year=2020, IsSummer=true, HostCountryId=1},
                new Olympiad(){Year=2016, IsSummer=true, HostCountryId=2},
                new Olympiad(){Year=2012, IsSummer=true, HostCountryId=3},
                new Olympiad(){Year=2018, IsSummer=false, HostCountryId=4},
                new Olympiad(){Year=2014, IsSummer=false, HostCountryId=5}
            };
            CityOlympiad[] cityOlympiads = new CityOlympiad[]
            {
                new CityOlympiad(){CityId=1, OlympiadYear=2020},
                new CityOlympiad(){CityId=2, OlympiadYear=2016},
                new CityOlympiad(){CityId=3, OlympiadYear=2012},
                new CityOlympiad(){CityId=4, OlympiadYear=2018},
                new CityOlympiad(){CityId=5, OlympiadYear=2014},
            };
            Discipline[] disciplines = new Discipline[]
            {
                new Discipline(){ Id=1, OlympiadYear=2020, TypeOfSportId=1},
                new Discipline(){ Id=2, OlympiadYear=2020, TypeOfSportId=2},
                new Discipline(){ Id=3, OlympiadYear=2020, TypeOfSportId=3},
                new Discipline(){ Id=4, OlympiadYear=2016, TypeOfSportId=1},
                new Discipline(){ Id=5, OlympiadYear=2016, TypeOfSportId=2},
                new Discipline(){ Id=6, OlympiadYear=2016, TypeOfSportId=3},
                new Discipline(){ Id=7, OlympiadYear=2012, TypeOfSportId=1},
                new Discipline(){ Id=8, OlympiadYear=2012, TypeOfSportId=2},
                new Discipline(){ Id=9, OlympiadYear=2012, TypeOfSportId=3},
                new Discipline(){ Id=10, OlympiadYear=2018, TypeOfSportId=4},
                new Discipline(){ Id=11, OlympiadYear=2018, TypeOfSportId=5},
                new Discipline(){ Id=12, OlympiadYear=2014, TypeOfSportId=4},
                new Discipline(){ Id=13, OlympiadYear=2014, TypeOfSportId=5}
            };
            Configures config = new Configures("appsettings.json");
            string picturesDirectoryPath = config.GetStringParameter("PicturesDirectoryPath");
            Participant[] participants = new Participant[]
            {
                new Participant()
                {
                    Id=1,
                    CountryId=1,
                    DateOfBirth=DateTime.Parse("02/02/1988"),
                    FirstName="Roberto",
                    LastName="Ozon",
                    MiddleName="Volinkov",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}1.jpg")
                },
                new Participant()
                {
                    Id=2,
                    CountryId=2,
                    DateOfBirth=DateTime.Parse("12/05/1992"),
                    FirstName="Mikal",
                    LastName="Vinsd",
                    MiddleName="Morrison",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}2.jpg")
                },
                new Participant()
                {
                    Id=3,
                    CountryId=3,
                    DateOfBirth=DateTime.Parse("08/10/1991"),
                    FirstName="Jonatan",
                    LastName="Jons",
                    MiddleName="Nestol",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}3.jpg")
                },
                new Participant()
                {
                    Id=4,
                    CountryId=4,
                    DateOfBirth=DateTime.Parse("18/01/1984"),
                    FirstName="Wolf",
                    LastName="Mondis",
                    MiddleName="Keris",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}4.jpg")
                },
                new Participant()
                {
                    Id=5,
                    CountryId=5,
                    DateOfBirth=DateTime.Parse("10/02/1991"),
                    FirstName="Nelson",
                    LastName="Bonkar",
                    MiddleName="Fasten",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}5.jpg")
                },
                new Participant()
                {
                    Id=6,
                    CountryId=1,
                    DateOfBirth=DateTime.Parse("24/08/1989"),
                    FirstName="Walter",
                    LastName="Ponusky",
                    MiddleName="Refend",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}6.jpg"),
                },
                new Participant()
                {
                    Id=7,
                    CountryId=2,
                    DateOfBirth=DateTime.Parse("21/05/1984"),
                    FirstName="Malkom",
                    LastName="Konsly",
                    MiddleName="Donks",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}7.jpg")
                },
                new Participant()
                {
                    Id=8,
                    CountryId=3,
                    DateOfBirth=DateTime.Parse("14/09/1990"),
                    FirstName="Brine",
                    LastName="Sollens",
                    MiddleName="Zarich",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}8.jpg")
                },
                new Participant()
                {
                    Id=9,
                    CountryId=4,
                    DateOfBirth=DateTime.Parse("12/06/1992"),
                    FirstName="Bruce",
                    LastName="Podolsky",
                    MiddleName="Kolenvas",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}9.jpg")
                },
                new Participant()
                {
                    Id=10,
                    CountryId=5,
                    DateOfBirth=DateTime.Parse("24/09/1987"),
                    FirstName="Nick",
                    LastName="Selin",
                    MiddleName="Tolkvist",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}10.jpg")
                },
                new Participant()
                {
                    Id=11,
                    CountryId=1,
                    DateOfBirth=DateTime.Parse("02/01/1995"),
                    FirstName="Xand",
                    LastName="Dorrest",
                    MiddleName="Milkov",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}11.jpg")
                },
                new Participant()
                {
                    Id=12,
                    CountryId=2,
                    DateOfBirth=DateTime.Parse("27/08/1990"),
                    FirstName="Bold",
                    LastName="Jesons",
                    MiddleName="Polister",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}12.jpg")
                },
                new Participant()
                {
                    Id=13,
                    CountryId=3,
                    DateOfBirth=DateTime.Parse("09/11/1990"),
                    FirstName="Lester",
                    LastName="Vronks",
                    MiddleName="Lenvost",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}13.jpg")
                },
                new Participant()
                {
                    Id=14,
                    CountryId=1,
                    DateOfBirth=DateTime.Parse("02/12/1992"),
                    FirstName="Sink",
                    LastName="Renkist",
                    MiddleName="Jerom",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}14.jpg")
                },
                new Participant()
                {
                    Id=15,
                    CountryId=2,
                    DateOfBirth=DateTime.Parse("14/04/1989"),
                    FirstName="Milvan",
                    LastName="Jonks",
                    MiddleName="Trevor",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}15.jpg")
                },
                new Participant()
                {
                    Id=16,
                    CountryId=3,
                    DateOfBirth=DateTime.Parse("04/06/1993"),
                    FirstName="Folin",
                    LastName="Inkost",
                    MiddleName="Fernis",
                    Photo=PictureCreator.Download($"{picturesDirectoryPath}16.jpg")
                }
            };
            ParticipantTypeOfSport[] participantTypeOfSports = new ParticipantTypeOfSport[]
            {
                new ParticipantTypeOfSport(){ ParticipantId=1, TypeOfSportId=1},
                new ParticipantTypeOfSport(){ ParticipantId=2, TypeOfSportId=2},
                new ParticipantTypeOfSport(){ ParticipantId=2, TypeOfSportId=3},
                new ParticipantTypeOfSport(){ ParticipantId=3, TypeOfSportId=3},
                new ParticipantTypeOfSport(){ ParticipantId=4, TypeOfSportId=1},
                new ParticipantTypeOfSport(){ ParticipantId=5, TypeOfSportId=2},
                new ParticipantTypeOfSport(){ ParticipantId=6, TypeOfSportId=3},
                new ParticipantTypeOfSport(){ ParticipantId=7, TypeOfSportId=1},
                new ParticipantTypeOfSport(){ ParticipantId=8, TypeOfSportId=2},
                new ParticipantTypeOfSport(){ ParticipantId=9, TypeOfSportId=3},
                new ParticipantTypeOfSport(){ ParticipantId=10, TypeOfSportId=1},
                new ParticipantTypeOfSport(){ ParticipantId=10, TypeOfSportId=2},
                new ParticipantTypeOfSport(){ ParticipantId=11, TypeOfSportId=4},
                new ParticipantTypeOfSport(){ ParticipantId=12, TypeOfSportId=5},
                new ParticipantTypeOfSport(){ ParticipantId=13, TypeOfSportId=4},
                new ParticipantTypeOfSport(){ ParticipantId=14, TypeOfSportId=5},
                new ParticipantTypeOfSport(){ ParticipantId=15, TypeOfSportId=4},
                new ParticipantTypeOfSport(){ ParticipantId=16, TypeOfSportId=4},
                new ParticipantTypeOfSport(){ ParticipantId=16, TypeOfSportId=5}
            };
            DisciplineParticipant[] disciplineParticipants = new DisciplineParticipant[]
            {
                new DisciplineParticipant(){ ParticipantId=1, DisciplineId=1},
                new DisciplineParticipant(){ ParticipantId=1, DisciplineId=4},
                new DisciplineParticipant(){ ParticipantId=1, DisciplineId=7},
                new DisciplineParticipant(){ ParticipantId=2, DisciplineId=2},
                new DisciplineParticipant(){ ParticipantId=2, DisciplineId=5},
                new DisciplineParticipant(){ ParticipantId=2, DisciplineId=8},
                new DisciplineParticipant(){ ParticipantId=2, DisciplineId=3},
                new DisciplineParticipant(){ ParticipantId=2, DisciplineId=6},
                new DisciplineParticipant(){ ParticipantId=2, DisciplineId=9},
                new DisciplineParticipant(){ ParticipantId=3, DisciplineId=3},
                new DisciplineParticipant(){ ParticipantId=3, DisciplineId=6},
                new DisciplineParticipant(){ ParticipantId=3, DisciplineId=9},
                new DisciplineParticipant(){ ParticipantId=4, DisciplineId=1},
                new DisciplineParticipant(){ ParticipantId=4, DisciplineId=4},
                new DisciplineParticipant(){ ParticipantId=4, DisciplineId=7},
                new DisciplineParticipant(){ ParticipantId=5, DisciplineId=2},
                new DisciplineParticipant(){ ParticipantId=5, DisciplineId=5},
                new DisciplineParticipant(){ ParticipantId=5, DisciplineId=8},
                new DisciplineParticipant(){ ParticipantId=6, DisciplineId=3},
                new DisciplineParticipant(){ ParticipantId=6, DisciplineId=6},
                new DisciplineParticipant(){ ParticipantId=6, DisciplineId=9},
                new DisciplineParticipant(){ ParticipantId=7, DisciplineId=1},
                new DisciplineParticipant(){ ParticipantId=7, DisciplineId=4},
                new DisciplineParticipant(){ ParticipantId=7, DisciplineId=7},
                new DisciplineParticipant(){ ParticipantId=8, DisciplineId=2},
                new DisciplineParticipant(){ ParticipantId=8, DisciplineId=5},
                new DisciplineParticipant(){ ParticipantId=8, DisciplineId=8},
                new DisciplineParticipant(){ ParticipantId=9, DisciplineId=3},
                new DisciplineParticipant(){ ParticipantId=9, DisciplineId=6},
                new DisciplineParticipant(){ ParticipantId=9, DisciplineId=9},
                new DisciplineParticipant(){ ParticipantId=10, DisciplineId=1},
                new DisciplineParticipant(){ ParticipantId=10, DisciplineId=4},
                new DisciplineParticipant(){ ParticipantId=10, DisciplineId=7},
                new DisciplineParticipant(){ ParticipantId=10, DisciplineId=2},
                new DisciplineParticipant(){ ParticipantId=10, DisciplineId=5},
                new DisciplineParticipant(){ ParticipantId=10, DisciplineId=8},
                new DisciplineParticipant(){ ParticipantId=11, DisciplineId=10},
                new DisciplineParticipant(){ ParticipantId=11, DisciplineId=12},
                new DisciplineParticipant(){ ParticipantId=12, DisciplineId=11},
                new DisciplineParticipant(){ ParticipantId=12, DisciplineId=13},
                new DisciplineParticipant(){ ParticipantId=13, DisciplineId=10},
                new DisciplineParticipant(){ ParticipantId=13, DisciplineId=12},
                new DisciplineParticipant(){ ParticipantId=14, DisciplineId=11},
                new DisciplineParticipant(){ ParticipantId=14, DisciplineId=13},
                new DisciplineParticipant(){ ParticipantId=16, DisciplineId=10},
                new DisciplineParticipant(){ ParticipantId=16, DisciplineId=12},
                new DisciplineParticipant(){ ParticipantId=16, DisciplineId=11},
                new DisciplineParticipant(){ ParticipantId=16, DisciplineId=13},
            };
            ResultParticipant[] resultParticipants = new ResultParticipant[]
            {
                new ResultParticipant(){ Id=1, ParticipantId=1, DisciplineId=1, Position=1},
                new ResultParticipant(){ Id=2, ParticipantId=4, DisciplineId=1, Position=2},
                new ResultParticipant(){ Id=3, ParticipantId=7, DisciplineId=1, Position=4},
                new ResultParticipant(){ Id=4, ParticipantId=10, DisciplineId=1, Position=3},
                new ResultParticipant(){ Id=5, ParticipantId=2, DisciplineId=2, Position=2},
                new ResultParticipant(){ Id=6, ParticipantId=5, DisciplineId=2, Position=1},
                new ResultParticipant(){ Id=7, ParticipantId=8, DisciplineId=2, Position=4},
                new ResultParticipant(){ Id=8, ParticipantId=10, DisciplineId=2, Position=3},
                new ResultParticipant(){ Id=9, ParticipantId=2, DisciplineId=3, Position=3},
                new ResultParticipant(){ Id=10, ParticipantId=3, DisciplineId=3, Position=1},
                new ResultParticipant(){ Id=11, ParticipantId=6, DisciplineId=3, Position=2},
                new ResultParticipant(){ Id=12, ParticipantId=9, DisciplineId=3, Position=4},
                new ResultParticipant(){ Id=13, ParticipantId=1, DisciplineId=4, Position=1},
                new ResultParticipant(){ Id=14, ParticipantId=4, DisciplineId=4, Position=3},
                new ResultParticipant(){ Id=15, ParticipantId=7, DisciplineId=4, Position=4},
                new ResultParticipant(){ Id=16, ParticipantId=10, DisciplineId=4, Position=2},
                new ResultParticipant(){ Id=17, ParticipantId=2, DisciplineId=5, Position=1},
                new ResultParticipant(){ Id=18, ParticipantId=5, DisciplineId=5, Position=2},
                new ResultParticipant(){ Id=19, ParticipantId=8, DisciplineId=5, Position=4},
                new ResultParticipant(){ Id=20, ParticipantId=10, DisciplineId=5, Position=3},
                new ResultParticipant(){ Id=21, ParticipantId=2, DisciplineId=6, Position=2},
                new ResultParticipant(){ Id=22, ParticipantId=3, DisciplineId=6, Position=1},
                new ResultParticipant(){ Id=23, ParticipantId=6, DisciplineId=6, Position=3},
                new ResultParticipant(){ Id=24, ParticipantId=9, DisciplineId=6, Position=4},
                new ResultParticipant(){ Id=25, ParticipantId=1, DisciplineId=7, Position=2},
                new ResultParticipant(){ Id=26, ParticipantId=4, DisciplineId=7, Position=4},
                new ResultParticipant(){ Id=27, ParticipantId=7, DisciplineId=7, Position=3},
                new ResultParticipant(){ Id=28, ParticipantId=10, DisciplineId=7, Position=1},
                new ResultParticipant(){ Id=29, ParticipantId=2, DisciplineId=8, Position=3},
                new ResultParticipant(){ Id=30, ParticipantId=5, DisciplineId=8, Position=1},
                new ResultParticipant(){ Id=31, ParticipantId=8, DisciplineId=8, Position=2},
                new ResultParticipant(){ Id=32, ParticipantId=10, DisciplineId=8, Position=4},
                new ResultParticipant(){ Id=33, ParticipantId=2, DisciplineId=9, Position=1},
                new ResultParticipant(){ Id=34, ParticipantId=3, DisciplineId=9, Position=2},
                new ResultParticipant(){ Id=35, ParticipantId=6, DisciplineId=9, Position=3},
                new ResultParticipant(){ Id=36, ParticipantId=9, DisciplineId=9, Position=4},
                new ResultParticipant(){ Id=37, ParticipantId=11, DisciplineId=10, Position=1},
                new ResultParticipant(){ Id=38, ParticipantId=13, DisciplineId=10, Position=2},
                new ResultParticipant(){ Id=39, ParticipantId=15, DisciplineId=10, Position=3},
                new ResultParticipant(){ Id=40, ParticipantId=16, DisciplineId=10, Position=4},
                new ResultParticipant(){ Id=41, ParticipantId=12, DisciplineId=11, Position=2},
                new ResultParticipant(){ Id=42, ParticipantId=14, DisciplineId=11, Position=1},
                new ResultParticipant(){ Id=43, ParticipantId=16, DisciplineId=11, Position=3},
                new ResultParticipant(){ Id=44, ParticipantId=11, DisciplineId=12, Position=2},
                new ResultParticipant(){ Id=45, ParticipantId=13, DisciplineId=12, Position=4},
                new ResultParticipant(){ Id=46, ParticipantId=15, DisciplineId=12, Position=4},
                new ResultParticipant(){ Id=47, ParticipantId=16, DisciplineId=12, Position=3},
                new ResultParticipant(){ Id=48, ParticipantId=12, DisciplineId=13, Position=1},
                new ResultParticipant(){ Id=49, ParticipantId=14, DisciplineId=13, Position=2},
                new ResultParticipant(){ Id=50, ParticipantId=16, DisciplineId=13, Position=3}
            };
            modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<City>().HasData(cities);
            modelBuilder.Entity<TypeOfSport>().HasData(typeOfSports);
            modelBuilder.Entity<Olympiad>().HasData(olympiads);
            modelBuilder.Entity<CityOlympiad>().HasData(cityOlympiads);
            modelBuilder.Entity<Discipline>().HasData(disciplines);
            modelBuilder.Entity<Participant>().HasData(participants);
            modelBuilder.Entity<ParticipantTypeOfSport>().HasData(participantTypeOfSports);
            modelBuilder.Entity<DisciplineParticipant>().HasData(disciplineParticipants);
            modelBuilder.Entity<ResultParticipant>().HasData(resultParticipants);
        }
    }
}
