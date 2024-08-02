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
            #endregion

            #region Item
            modelBuilder.Entity<Item>().HasKey(x => x.Id);
            modelBuilder.Entity<Item>().Property(e => e.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (ItemEnum)Enum.Parse(typeof(ItemEnum), v)
                    );
            modelBuilder.Entity<Item>().Property(e => e.State)
                .HasConversion(
                    v => v.ToString(),
                    v => (ItemState)Enum.Parse(typeof(ItemState), v)
                    );
            #endregion

            #region Human
            modelBuilder.Entity<Human>().HasKey(x => x.Id);
            modelBuilder.Entity<Human>().Property(e => e.FeelToDegree)
                .HasConversion(
                    v => v.ToString(),
                    v => (FeelToDegreeEnum)Enum.Parse(typeof(FeelToDegreeEnum), v)
                    );
            modelBuilder.Entity<Human>().Property(e => e.BodyStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (BodyStatusEnum)Enum.Parse(typeof(BodyStatusEnum), v)
                    );
            modelBuilder.Entity<Human>().Property(e => e.MentalStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (MentalStatusEnum)Enum.Parse(typeof(MentalStatusEnum), v)
                    );
            #endregion

            #region ActionCondition
            modelBuilder.Entity<ActionCondition>().HasKey(x => x.Id);
            modelBuilder.Entity<ActionCondition>().Property(e => e.ConditionType)
                .HasConversion(
                    v => v.ToString(),
                    v => (CaseStudyEnum)Enum.Parse(typeof(CaseStudyEnum), v)
                    );
            modelBuilder.Entity<ActionCondition>().Property(e => e.ConditionCaseType)
                .HasConversion(
                    v => v.ToString(),
                    v => (ConditionCaseEnum)Enum.Parse(typeof(ConditionCaseEnum), v)
                    );
            #endregion

            #region ActionResult
            modelBuilder.Entity<ActionResult>().HasKey(x => x.Id);
            modelBuilder.Entity<ActionResult>().Property(e => e.ResultType)
                .HasConversion(
                    v => v.ToString(),
                    v => (CaseStudyEnum)Enum.Parse(typeof(CaseStudyEnum), v)
                    );
            modelBuilder.Entity<ActionResult>().Property(e => e.ResultCaseType)
                .HasConversion(
                    v => v.ToString(),
                    v => (ResultCaseEnum)Enum.Parse(typeof(ResultCaseEnum), v)
                    );
            #endregion

            #region NextAction
            modelBuilder.Entity<NextAction>().HasKey(x => new { x.Id, x.ActionAggregateId });
            #endregion

            #region ActionAggregate
            modelBuilder.Entity<ActionAggregate>().HasKey(x => x.Id);
            modelBuilder.Entity<ActionAggregate>().HasMany(x => x.Conditions)
                .WithOne(x => x.ActionAggregate).HasForeignKey(x => x.ActionAggregateId);
            modelBuilder.Entity<ActionAggregate>().HasMany(x => x.Results)
                .WithOne(x => x.ActionAggregate).HasForeignKey(x => x.ActionAggregateId);
            modelBuilder.Entity<ActionAggregate>().HasMany(x => x.NextActions)
                .WithOne(x => x.ActionAggregate).HasForeignKey(x => x.ActionAggregateId);

            #region Ids
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var guid3 = Guid.NewGuid();
            var guid4 = Guid.NewGuid();
            var guid5 = Guid.NewGuid();
            var guid6 = Guid.NewGuid();
            var guid7 = Guid.NewGuid();
            var guid8 = Guid.NewGuid();
            var guid9 = Guid.NewGuid();
            var guid10 = Guid.NewGuid();
            var guid11 = Guid.NewGuid();
            var guid12 = Guid.NewGuid();
            var guid13 = Guid.NewGuid();
            var guid14 = Guid.NewGuid();
            var guid15 = Guid.NewGuid();
            var guid16 = Guid.NewGuid();
            var guid17 = Guid.NewGuid();
            var guid18 = Guid.NewGuid();
            var guid19 = Guid.NewGuid();
            var guid20 = Guid.NewGuid();
            var guid21 = Guid.NewGuid();
            var guid22 = Guid.NewGuid();
            var guid23 = Guid.NewGuid();
            var guid24 = Guid.NewGuid();
            #endregion

            #region Actions
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid1,
                    Name = "Entrance|Entering",
                    Delay = 131,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid2,
                    Name = "Staircase|Going_up",
                    Delay = 53,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid3,
                    Name = "Bathroom|Showering",
                    Delay = 1063,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid4,
                    Name = "Bathroom|Using_the_sink",
                    Delay = 207,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid5,
                    Name = "Staircase|Going_down",
                    Delay = 53,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid6,
                    Name = "Living_room|Watching_TV",
                    Delay = 1668,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid7,
                    Name = "Toilet|Using_the_toilet",
                    Delay = 147,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid8,
                    Name = "Office|Computing",
                    Delay = 9225,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid9,
                    Name = "Kitchen|Preparing",
                    Delay = 112,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid10,
                    Name = "Kitchen|Cooking",
                    Delay = 692,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid11,
                    Name = "Living_room|Eating",
                    Delay = 712,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid12,
                    Name = "Kitchen|Washing_the_dishes",
                    Delay = 381,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid13,
                    Name = "Living_room|Cleaning",
                    Delay = 90,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid14,
                    Name = "Living_room|Computing",
                    Delay = 1882,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid15,
                    Name = "Bedroom|Dressing",
                    Delay = 95,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid16,
                    Name = "Bedroom|Reading",
                    Delay = 1738,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid17,
                    Name = "Bedroom|Napping",
                    Delay = 1646,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid18,
                    Name = "Bathroom|Using_the_toilet",
                    Delay = 222,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid19,
                    Name = "Office|Watching_TV",
                    Delay = 1147,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid20,
                    Name = "Entrance|Leaving",
                    Delay = 89,
                    EndPossibility = 100
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid21,
                    Name = "Kitchen|Cleaning",
                    Delay = 119,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid22,
                    Name = "Bathroom|Cleaning",
                    Delay = 177,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid23,
                    Name = "Bedroom|Cleaning",
                    Delay = 132,
                    EndPossibility = 0
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid24,
                    Name = "Office|Cleaning",
                    Delay = 152,
                    EndPossibility = 0
                }
            );
            #endregion

            #region Nexts
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid2,
                    ActionAggregateId = guid1,
                    Possibility = 100,
                    Delay = 200
                }
            );
            #endregion

            #endregion

        }

    }

}