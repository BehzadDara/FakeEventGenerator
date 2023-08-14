using FakeEventGenerator.Domain.Enums;
using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure
{
    public class FakeEventGeneratorDBContext : DbContext
    {
        public DbSet<EnvironmentVariable>? EnvironmentVariables { get; set; }

        public FakeEventGeneratorDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}