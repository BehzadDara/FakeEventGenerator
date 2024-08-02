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

            modelBuilder.Entity<SensorDataEntity>().HasKey(x => x.Id);

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
            modelBuilder.Entity<ActionAggregate>().HasMany(x => x.ActionDetails)
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
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid2,
                    Name = "Staircase|Going_up",
                    Delay = 53,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid3,
                    Name = "Bathroom|Showering",
                    Delay = 1063,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid4,
                    Name = "Bathroom|Using_the_sink",
                    Delay = 207,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid5,
                    Name = "Staircase|Going_down",
                    Delay = 53,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid6,
                    Name = "Living_room|Watching_TV",
                    Delay = 1668,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid7,
                    Name = "Toilet|Using_the_toilet",
                    Delay = 147,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid8,
                    Name = "Office|Computing",
                    Delay = 9225,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid9,
                    Name = "Kitchen|Preparing",
                    Delay = 112,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid10,
                    Name = "Kitchen|Cooking",
                    Delay = 692,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid11,
                    Name = "Living_room|Eating",
                    Delay = 712,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid12,
                    Name = "Kitchen|Washing_the_dishes",
                    Delay = 381,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid13,
                    Name = "Living_room|Cleaning",
                    Delay = 90,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid14,
                    Name = "Living_room|Computing",
                    Delay = 1882,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid15,
                    Name = "Bedroom|Dressing",
                    Delay = 95,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid16,
                    Name = "Bedroom|Reading",
                    Delay = 1738,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid17,
                    Name = "Bedroom|Napping",
                    Delay = 1646,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid18,
                    Name = "Bathroom|Using_the_toilet",
                    Delay = 222,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid19,
                    Name = "Office|Watching_TV",
                    Delay = 1147,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid20,
                    Name = "Entrance|Leaving",
                    Delay = 89,
                    EndPossibility = 100,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid21,
                    Name = "Kitchen|Cleaning",
                    Delay = 119,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid22,
                    Name = "Bathroom|Cleaning",
                    Delay = 177,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid23,
                    Name = "Bedroom|Cleaning",
                    Delay = 132,
                    EndPossibility = 0,
                }
            );

            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid24,
                    Name = "Office|Cleaning",
                    Delay = 152,
                    EndPossibility = 0,
                }
            );
            #endregion

            #region Nexts

            #region 1
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid2,
                    ActionAggregateId = guid1,
                    Possibility = 90,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid7,
                    ActionAggregateId = guid1,
                    Possibility = 5,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid6,
                    ActionAggregateId = guid1,
                    Possibility = 6,
                    Delay = 1
                }
            );
            #endregion

            #region 2
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid3,
                    ActionAggregateId = guid2,
                    Possibility = 33,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid8,
                    ActionAggregateId = guid2,
                    Possibility = 33,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid4,
                    ActionAggregateId = guid2,
                    Possibility = 31,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid18,
                    ActionAggregateId = guid2,
                    Possibility = 3,
                    Delay = 1
                }
            );
            #endregion

            #region 3
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid4,
                    ActionAggregateId = guid3,
                    Possibility = 100,
                    Delay = 1
                }
            );
            #endregion

            #region 4
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid5,
                    ActionAggregateId = guid4,
                    Possibility = 44,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid15,
                    ActionAggregateId = guid4,
                    Possibility = 39,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid22,
                    ActionAggregateId = guid4,
                    Possibility = 8,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid8,
                    ActionAggregateId = guid4,
                    Possibility = 6,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid18,
                    ActionAggregateId = guid4,
                    Possibility = 3,
                    Delay = 1
                }
            );
            #endregion

            #region 5
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid6,
                    ActionAggregateId = guid5,
                    Possibility = 29,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid9,
                    ActionAggregateId = guid5,
                    Possibility = 33,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid20,
                    ActionAggregateId = guid5,
                    Possibility = 36,
                    Delay = 1
                }
            );
            #endregion

            #region 6
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid7,
                    ActionAggregateId = guid6,
                    Possibility = 12,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid2,
                    ActionAggregateId = guid6,
                    Possibility = 88,
                    Delay = 1
                }
            );
            #endregion

            #region 7
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid2,
                    ActionAggregateId = guid7,
                    Possibility = 62,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid14,
                    ActionAggregateId = guid7,
                    Possibility = 38,
                    Delay = 1
                }
            );
            #endregion

            #region 8
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid5,
                    ActionAggregateId = guid8,
                    Possibility = 47,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid18,
                    ActionAggregateId = guid8,
                    Possibility = 13,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid19,
                    ActionAggregateId = guid8,
                    Possibility = 30,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid24,
                    ActionAggregateId = guid8,
                    Possibility = 10,
                    Delay = 1
                }
            );
            #endregion

            #region 9
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid10,
                    ActionAggregateId = guid9,
                    Possibility = 100,
                    Delay = 1
                }
            );
            #endregion

            #region 10
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid11,
                    ActionAggregateId = guid10,
                    Possibility = 100,
                    Delay = 1
                }
            );
            #endregion

            #region 11
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid12,
                    ActionAggregateId = guid11,
                    Possibility = 100,
                    Delay = 1
                }
            );
            #endregion

            #region 12
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid13,
                    ActionAggregateId = guid12,
                    Possibility = 100,
                    Delay = 1
                }
            );
            #endregion

            #region 13
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid14,
                    ActionAggregateId = guid13,
                    Possibility = 63,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid21,
                    ActionAggregateId = guid13,
                    Possibility = 21,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid7,
                    ActionAggregateId = guid13,
                    Possibility = 16,
                    Delay = 1
                }
            );
            #endregion

            #region 14
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid2,
                    ActionAggregateId = guid14,
                    Possibility = 93,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid7,
                    ActionAggregateId = guid14,
                    Possibility = 7,
                    Delay = 1
                }
            );
            #endregion

            #region 15
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid16,
                    ActionAggregateId = guid15,
                    Possibility = 50,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid8,
                    ActionAggregateId = guid15,
                    Possibility = 46,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid18,
                    ActionAggregateId = guid15,
                    Possibility = 4,
                    Delay = 1
                }
            );
            #endregion

            #region 16
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid17,
                    ActionAggregateId = guid16,
                    Possibility = 100,
                    Delay = 1
                }
            );
            #endregion

            #region 17
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid15,
                    ActionAggregateId = guid17,
                    Possibility = 100,
                    Delay = 1
                }
            );
            #endregion

            #region 18
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid8,
                    ActionAggregateId = guid18,
                    Possibility = 77,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid4,
                    ActionAggregateId = guid18,
                    Possibility = 11,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid22,
                    ActionAggregateId = guid18,
                    Possibility = 12,
                    Delay = 1
                }
            );
            #endregion

            #region 19
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid5,
                    ActionAggregateId = guid19,
                    Possibility = 100,
                    Delay = 1
                }
            );
            #endregion

            #region 20
            #endregion

            #region 21
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid2,
                    ActionAggregateId = guid21,
                    Possibility = 75,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid7,
                    ActionAggregateId = guid21,
                    Possibility = 25,
                    Delay = 1
                }
            );
            #endregion

            #region 22
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid23,
                    ActionAggregateId = guid22,
                    Possibility = 75,
                    Delay = 1
                }
            );
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid8,
                    ActionAggregateId = guid22,
                    Possibility = 25,
                    Delay = 1
                }
            );
            #endregion

            #region 23
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid8,
                    ActionAggregateId = guid23,
                    Possibility = 100,
                    Delay = 1
                }
            );
            #endregion

            #region 24
            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid5,
                    ActionAggregateId = guid24,
                    Possibility = 100,
                    Delay = 1
                }
            );
            #endregion

            #endregion


            #region Detail
            modelBuilder.Entity<ActionDetail>().HasKey(x => x.Id);
            modelBuilder.Entity<ActionDetail>().HasMany(x => x.SensorDatas)
                .WithOne(x => x.ActionDetail).HasForeignKey(x => x.ActionDetailId);


            #endregion


            #endregion

        }



    }

}