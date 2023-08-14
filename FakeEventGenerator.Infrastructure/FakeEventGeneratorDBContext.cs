using FakeEventGenerator.Domain.Enums;
using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure
{
    public class FakeEventGeneratorDBContext : DbContext
    {
        public FakeEventGeneratorDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region EnvironmentVariable
            modelBuilder.Entity<EnvironmentVariable>().HasKey(x => x.Type);
            modelBuilder.Entity<EnvironmentVariable>().Property(e => e.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (EnvironmentVariableEnum)Enum.Parse(typeof(EnvironmentVariableEnum), v)
                    );
            modelBuilder.Entity<EnvironmentVariable>().HasData(
               new EnvironmentVariable { Type = EnvironmentVariableEnum.Degree, Value = 20 },
               new EnvironmentVariable { Type = EnvironmentVariableEnum.Light, Value = 10 },
               new EnvironmentVariable { Type = EnvironmentVariableEnum.Humidity, Value = 20 },
               new EnvironmentVariable { Type = EnvironmentVariableEnum.Sound, Value = 30 }
               );
            #endregion

            #region PartOfHouse
            modelBuilder.Entity<PartOfHouse>().HasKey(x => x.Type);
            modelBuilder.Entity<PartOfHouse>().Property(e => e.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (PartOfHouseEnum)Enum.Parse(typeof(PartOfHouseEnum), v)
                    );

            modelBuilder.Entity<PartOfHouse>().HasData(
               new PartOfHouse { Type = PartOfHouseEnum.House, 
                   Coordinate1X = 0, 
                   Coordinate1Y = 0, 
                   Coordinate2X = 100,
                   Coordinate2Y = 100
               },

               new PartOfHouse { Type = PartOfHouseEnum.LivingRoom,
                   Coordinate1X = 0,
                   Coordinate1Y = 0,
                   Coordinate2X = 30,
                   Coordinate2Y = 30
               },

               new PartOfHouse { Type = PartOfHouseEnum.Kitchen,
                   Coordinate1X = 30,
                   Coordinate1Y = 0,
                   Coordinate2X = 80,
                   Coordinate2Y = 30
               },

               new PartOfHouse { Type = PartOfHouseEnum.Bathroom,
                   Coordinate1X = 80,
                   Coordinate1Y = 0,
                   Coordinate2X = 100,
                   Coordinate2Y = 30
               },

               new PartOfHouse { Type = PartOfHouseEnum.Corridor,
                   Coordinate1X = 0,
                   Coordinate1Y = 30,
                   Coordinate2X = 100,
                   Coordinate2Y = 50
               },

               new PartOfHouse { Type = PartOfHouseEnum.Bedroom1,
                   Coordinate1X = 0,
                   Coordinate1Y = 50,
                   Coordinate2X = 50,
                   Coordinate2Y = 80
               },

               new PartOfHouse { Type = PartOfHouseEnum.Bedroom2,
                   Coordinate1X = 50,
                   Coordinate1Y = 50,
                   Coordinate2X = 100,
                   Coordinate2Y = 80
               },

               new PartOfHouse { Type = PartOfHouseEnum.Balcony,
                   Coordinate1X = 0,
                   Coordinate1Y = 80,
                   Coordinate2X = 100,
                   Coordinate2Y = 100
               }

            );
            #endregion

        }
    }
}