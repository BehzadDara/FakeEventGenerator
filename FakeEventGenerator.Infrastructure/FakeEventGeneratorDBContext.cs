using FakeEventGenerator.Domain.DTOs;
using FakeEventGenerator.Domain.Enums;
using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

            #region safebox
            var guid201 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid201,
                    Name = "Open-SafeBox",
                    Description = "Open SafeBox",
                    Delay = 1500,
                    EndPossibility = 0
                }
            );

            var guid202 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid202,
                    Name = "Close-SafeBox",
                    Description = "Close SafeBox",
                    Delay = 1000,
                    EndPossibility = 0
                }
            );
            #endregion

            #region Door
            modelBuilder.Entity<Item>().HasData(
               new Item
               {
                   Name = "HouseDoor",
                   Description = "House Door",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false
               },
               new Item
               {
                   Name = "LivingRoomDoor",
                   Description = "LivingRoom Door",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false
               },
               new Item
               {
                   Name = "KitchenDoor",
                   Description = "Kitchen Door",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.Kitchen,
                   IsMovable = false
               },
               new Item
               {
                   Name = "BathroomDoor",
                   Description = "Bathroom Door",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.Bathroom,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Bedroom1Door",
                   Description = "Bedroom1 Door",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.Bedroom1,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Bedroom2Door",
                   Description = "Bedroom2 Door",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.Bedroom2,
                   IsMovable = false
               },
               new Item
               {
                   Name = "BalconyDoor1",
                   Description = "Balcony Door1",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.Balcony,
                   IsMovable = false
               },
               new Item
               {
                   Name = "BalconyDoor2",
                   Description = "Balcony Door2",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.Balcony,
                   IsMovable = false
               },
            #endregion

            #region Window
               new Item
               {
                   Name = "Bedroom1Window",
                   Description = "Bedroom1 Window",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.Bedroom1,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Bedroom2Window",
                   Description = "Bedroom2 Window",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.Bedroom2,
                   IsMovable = false
               },
               new Item
               {
                   Name = "BalconyWindow",
                   Description = "Balcony Window",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.Balcony,
                   IsMovable = false
               },
            #endregion

            #region Bedroom Items
               new Item
               {
                   Name = "Bedroom1Bed",
                   Description = "Bedroom1 Bed",
                   Type = ItemEnum.UseWithCapacity,
                   State = ItemState.NotFull,
                   Location = PartOfHouseEnum.Bedroom1,
                   IsMovable = false
               },
               new Item
               {
                   Name = "AirConditioner1",
                   Description = "Bedroom1 AirConditioner",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.Bedroom1,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Computer",
                   Description = "Bedroom1 Computer",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.Bedroom1,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Chair11",
                   Description = "Bedroom1 Chair",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   Location = PartOfHouseEnum.Bedroom1,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Lamp1",
                   Description = "Bedroom1 Lamp",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.Bedroom1,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new LampMetaData
                   {
                       Severity = 20
                   })
               },

               new Item
               {
                   Name = "Bedroom2Bed",
                   Description = "Bedroom2 Bed",
                   Type = ItemEnum.UseWithCapacity,
                   State = ItemState.NotFull,
                   Location = PartOfHouseEnum.Bedroom2,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new AirConditionerMetaData
                   {
                       Temperature = 20,
                       Speed = 10
                   })
               },
               new Item
               {
                   Name = "AirConditioner2",
                   Description = "Bedroom2 AirConditioner",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.Bedroom2,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new AirConditionerMetaData
                   {
                       Temperature = 20,
                       Speed = 10
                   })
               },
               new Item
               {
                   Name = "Laptop",
                   Description = "Bedroom2 Laptop",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.Bedroom2,
                   IsMovable = true,
                   MetaData = JsonSerializer.Serialize(new LaptopMetaData
                   {
                       Charge = 90,
                       IsInCharge = false
                   })
               },
               new Item
               {
                   Name = "Chair21",
                   Description = "Bedroom2 Chair",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   Location = PartOfHouseEnum.Bedroom2,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Lamp2",
                   Description = "Bedroom2 Lamp",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.Bedroom2,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new LampMetaData
                   {
                       Severity = 20
                   })
               },
            #endregion

            #region Kitchen Items
               new Item
               {
                   Name = "Oven",
                   Description = "Kitchen Oven",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   Location = PartOfHouseEnum.Kitchen,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Refrigerator",
                   Description = "Kitchen Refrigerator",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.Kitchen,
                   IsMovable = false
               },
               new Item
               {
                   Name = "WashingMachine",
                   Description = "Kitchen WashingMachine",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   Location = PartOfHouseEnum.Kitchen,
                   IsMovable = false
               },
               new Item
               {
                   Name = "DishWasher",
                   Description = "Kitchen DishWasher",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   Location = PartOfHouseEnum.Kitchen,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Lamp3",
                   Description = "Kitchen Lamp",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.Kitchen,
                   IsMovable = false
               },
            #endregion

            #region LivingRoom Items
               new Item
               {
                   Name = "TV",
                   Description = "LivingRoom TV",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new TVMetaData
                   {
                       Channel = 1,
                       Sound = 60
                   })
               },
               new Item
               {
                   Name = "Sofa1",
                   Description = "LivingRoom Sofa1",
                   Type = ItemEnum.UseWithCapacity,
                   State = ItemState.NotFull,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new SofaMetaData
                   {
                       Capacity = 1
                   })
               },
               new Item
               {
                   Name = "Sofa2",
                   Description = "LivingRoom Sofa2",
                   Type = ItemEnum.UseWithCapacity,
                   State = ItemState.NotFull,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new SofaMetaData
                   {
                       Capacity = 2
                   })
               },
               new Item
               {
                   Name = "Sofa3",
                   Description = "LivingRoom Sofa3",
                   Type = ItemEnum.UseWithCapacity,
                   State = ItemState.NotFull,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new SofaMetaData
                   {
                       Capacity = 3
                   })
               },
               new Item
               {
                   Name = "Table",
                   Description = "LivingRoom Table",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Chair1",
                   Description = "LivingRoom Chair1",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Chair2",
                   Description = "LivingRoom Chair2",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Chair3",
                   Description = "LivingRoom Chair3",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Chair4",
                   Description = "LivingRoom Chair4",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false
               },
               new Item
               {
                   Name = "AirConditioner3",
                   Description = "LivingRoom AirConditioner",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new AirConditionerMetaData
                   {
                       Temperature = 20,
                       Speed = 10
                   })
               },
               new Item
               {
                   Name = "Lamp4",
                   Description = "LivingRoom Lamp",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.LivingRoom,
                   IsMovable = false
               },
            #endregion

            #region Bathroom
               new Item
               {
                   Name = "Lamp5",
                   Description = "Bathroom Lamp",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.Bathroom,
                   IsMovable = false
               },
            #endregion

            #region Balcony
               new Item
               {
                   Name = "Lamp6",
                   Description = "Balcony Lamp",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.Balcony,
                   IsMovable = false
               },
            #endregion

            #region Corridor
               new Item
               {
                   Name = "Lamp7",
                   Description = "Corridor Lamp",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   Location = PartOfHouseEnum.Corridor,
                   IsMovable = false
               },
               new Item
               {
                   Name = "SafeBox",
                   Description = "Safe Box",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   Location = PartOfHouseEnum.Corridor,
                   IsMovable = false
               }
               #endregion

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

            modelBuilder.Entity<Human>().HasData(
                new Human
                {
                    Name = "Human1",
                    Location = PartOfHouseEnum.Bedroom1,
                    FeelToDegree = FeelToDegreeEnum.Medium,
                    BodyStatus = BodyStatusEnum.Stand,
                    MentalStatus = MentalStatusEnum.Tired
                },
                new Human
                {
                    Name = "Human2",
                    Location = PartOfHouseEnum.Bedroom2,
                    FeelToDegree = FeelToDegreeEnum.Medium,
                    BodyStatus = BodyStatusEnum.Stand,
                    MentalStatus = MentalStatusEnum.Bored
                }
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

            #region OpenBalconyWindow
            var guid1 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid1,
                    Name = "Open-BalconyDoor1",
                    Description = "Open Door1 Of Balcony",
                    Delay = 500,
                    EndPossibility = 100
                }
            );

            var guid2 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid2,
                    Name = "Move-Balcony-Bedroom1",
                    Description = "Move To Balcony Human1 Via Bedroom1",
                    Delay = 500,
                    EndPossibility = 100,
                }
            );

            var guid3 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid3,
                    Name = "Open-BalconyWindow",
                    Description = "Open Window Of Balcony",
                    Delay = 100,
                    EndPossibility = 100
                }
            );

            var guid4 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid4,
                    Name = "Sit-BalconyWindow",
                    Description = "Sit Under BalconyWindow",
                    Delay = 50,
                    EndPossibility = 100
                }
            );

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid1,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human1",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "Bedroom1"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid1,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human1",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Stand"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid1,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "BalconyDoor1",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Close"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid1,
                    ResultType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human1",
                    ResultCaseType = ResultCaseEnum.Position,
                    ResultCaseChange = "Bedroom1"
                },
                new ActionResult
                {
                    ActionAggregateId = guid1,
                    ResultType = CaseStudyEnum.ItemState,
                    CaseStudy = "BalconyDoor1",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Open"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid2,
                    ActionAggregateId = guid1,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 200
                }
            );
            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid2,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human1",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "Bedroom1"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid2,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human1",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Stand"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid2,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "BalconyDoor1",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Open"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid2,
                    ResultType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human1",
                    ResultCaseType = ResultCaseEnum.Position,
                    ResultCaseChange = "Balcony"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid3,
                    ActionAggregateId = guid2,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 200
                }
            );
            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid3,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human1",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "Balcony"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid3,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human1",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Stand"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid3,
                    ResultType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human1",
                    ResultCaseType = ResultCaseEnum.Position,
                    ResultCaseChange = "Balcony"
                },
                new ActionResult
                {
                    ActionAggregateId = guid3,
                    ResultType = CaseStudyEnum.ItemState,
                    CaseStudy = "BalconyWindow",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Open"
                },
                new ActionResult
                {
                    ActionAggregateId = guid3,
                    ResultType = CaseStudyEnum.Environment,
                    CaseStudy = "Light",
                    ResultCaseType = ResultCaseEnum.Increase,
                    ResultCaseChange = "20-IF:Day"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid4,
                    ActionAggregateId = guid3,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 100
                }
            );
            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid4,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human1",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "Balcony"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid4,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human1",
                    ConditionCaseType = ConditionCaseEnum.StateIsNot,
                    ConditionCaseExpectation = "Sit"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid4,
                    ConditionType = CaseStudyEnum.MentalStatus,
                    CaseStudy = "Human1",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Tired"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid4,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "BalconyWindow",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Open"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid4,
                    ResultType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human1",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Sit"
                },
                new ActionResult
                {
                    ActionAggregateId = guid4,
                    ResultType = CaseStudyEnum.MentalStatus,
                    CaseStudy = "Human1",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Normal"
                }
            );
            #endregion

            #endregion

            #region IncreaseSound
            var guid11 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid11,
                    Name = "Open-Bedroom2Door",
                    Description = "Open Door Of Bedroom2",
                    Delay = 1500,
                    EndPossibility = 100
                }
            );

            var guid12 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid12,
                    Name = "Move-Corridor-Bedroom1",
                    Description = "Move To Corridor Human2 Via Bedroom2",
                    Delay = 500,
                    EndPossibility = 100,
                }
            );

            var guid13 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid13,
                    Name = "Open-LivinRoomDoor",
                    Description = "Open Door Of LivingRoom",
                    Delay = 400,
                    EndPossibility = 100
                }
            );

            var guid14 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid14,
                    Name = "Move-LivingRoom-Corridor",
                    Description = "Move To LivingRoom Human2 Via Corridor",
                    Delay = 100,
                    EndPossibility = 100
                }
            );

            var guid15 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid15,
                    Name = "Sit-Sofa1",
                    Description = "Sit On Sofa1",
                    Delay = 800,
                    EndPossibility = 100
                }
            );

            var guid16 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid16,
                    Name = "On-TV",
                    Description = "Turn On TV",
                    Delay = 200,
                    EndPossibility = 50
                }
            );

            var guid17 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid17,
                    Name = "Increase-Sound",
                    Description = "Increase Sound Of TV",
                    Delay = 350,
                    EndPossibility = 100
                }
            );

            var guid18 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid18,
                    Name = "Decrease-Sound",
                    Description = "Decrease Sound Of TV",
                    Delay = 350,
                    EndPossibility = 100
                }
            );

            #region One ActionAggregate
            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid11,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "Bedroom2"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid11,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Stand"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid11,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "Bedroom1Door",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Close"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid11,
                    ResultType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human1",
                    ResultCaseType = ResultCaseEnum.Position,
                    ResultCaseChange = "Bedroom2"
                },
                new ActionResult
                {
                    ActionAggregateId = guid11,
                    ResultType = CaseStudyEnum.ItemState,
                    CaseStudy = "Bedroom2Door",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Open"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid12,
                    ActionAggregateId = guid11,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 200
                }
            );
            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid12,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "Bedroom2"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid12,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Stand"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid12,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "Bedroom2Door",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Open"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid12,
                    ResultType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ResultCaseType = ResultCaseEnum.Position,
                    ResultCaseChange = "Corridor"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid13,
                    ActionAggregateId = guid12,
                    //NumberOfActions = 1,
                    Possibility = 50,
                    Delay = 200
                },
                new NextAction
                {
                    Id = guid201,
                    ActionAggregateId = guid12,
                    //NumberOfActions = 1,
                    Possibility = 50,
                    Delay = 150
                }
            );
            #endregion

            #region One ActionAggregate
            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid13,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "Corridor"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid13,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Stand"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid13,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "LivingRoomDoor",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Close"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid13,
                    ResultType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ResultCaseType = ResultCaseEnum.Position,
                    ResultCaseChange = "Corridor"
                },
                new ActionResult
                {
                    ActionAggregateId = guid13,
                    ResultType = CaseStudyEnum.ItemState,
                    CaseStudy = "LivingRoomDoor",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Open"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid14,
                    ActionAggregateId = guid13,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 200
                }
            );
            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid14,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "Corridor"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid14,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Stand"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid14,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "LivingRoomDoor",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Open"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid14,
                    ResultType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ResultCaseType = ResultCaseEnum.Position,
                    ResultCaseChange = "LivingRoom"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid15,
                    ActionAggregateId = guid14,
                    //NumberOfActions = 1,
                    Possibility = 30,
                    Delay = 200
                }
            );

            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid15,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "LivingRoom"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid15,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Stand"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid15,
                    ResultType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ResultCaseType = ResultCaseEnum.Position,
                    ResultCaseChange = "LivingRoom"
                },
                new ActionResult
                {
                    ActionAggregateId = guid15,
                    ResultType = CaseStudyEnum.ItemState,
                    CaseStudy = "Sofa1",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Full"
                },
                new ActionResult
                {
                    ActionAggregateId = guid15,
                    ResultType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Sit"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid16,
                    ActionAggregateId = guid15,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 200
                }
            );
            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid16,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "LivingRoom"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid16,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Sit"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid16,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "TV",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Off"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid16,
                    ResultType = CaseStudyEnum.MentalStatus,
                    CaseStudy = "Human2",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Normal"
                },
                new ActionResult
                {
                    ActionAggregateId = guid16,
                    ResultType = CaseStudyEnum.ItemState,
                    CaseStudy = "TV",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "On"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid17,
                    ActionAggregateId = guid16,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 200
                },
                new NextAction
                {
                    Id = guid18,
                    ActionAggregateId = guid16,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 200
                }
            );
            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid17,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "LivingRoom"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid17,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Sit"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid17,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "TV",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "On"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid17,
                    ResultType = CaseStudyEnum.Environment,
                    CaseStudy = "Light",
                    ResultCaseType = ResultCaseEnum.Increase,
                    ResultCaseChange = "10"
                },
                new ActionResult
                {
                    ActionAggregateId = guid17,
                    ResultType = CaseStudyEnum.Environment,
                    CaseStudy = "Sound",
                    ResultCaseType = ResultCaseEnum.Increase,
                    ResultCaseChange = "10-40"
                },
                new ActionResult
                {
                    ActionAggregateId = guid17,
                    ResultType = CaseStudyEnum.ItemMetaData,
                    CaseStudy = "TV-Sound",
                    ResultCaseType = ResultCaseEnum.Increase,
                    ResultCaseChange = "10-40"
                }
            );

            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid18,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "LivingRoom"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid18,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Sit"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid18,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "TV",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "On"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid18,
                    ResultType = CaseStudyEnum.Environment,
                    CaseStudy = "Light",
                    ResultCaseType = ResultCaseEnum.Increase,
                    ResultCaseChange = "10"
                },
                new ActionResult
                {
                    ActionAggregateId = guid18,
                    ResultType = CaseStudyEnum.Environment,
                    CaseStudy = "Sound",
                    ResultCaseType = ResultCaseEnum.Decrease,
                    ResultCaseChange = "10-40"
                },
                new ActionResult
                {
                    ActionAggregateId = guid18,
                    ResultType = CaseStudyEnum.ItemMetaData,
                    CaseStudy = "TV-Sound",
                    ResultCaseType = ResultCaseEnum.Decrease,
                    ResultCaseChange = "10-40"
                }
            );

            #endregion

            #endregion

            #region HumanFeelCold
            var guid25 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid25,
                    Name = "On-AirConditioner3",
                    Description = "Turn On AirConditioner3",
                    Delay = 600,
                    EndPossibility = 100
                }
            );

            var guid26 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid26,
                    Name = "Decrease-Degree",
                    Description = "Decrease Degree Of AirConditioner3",
                    Delay = 200,
                    EndPossibility = 100
                }
            );

            var guid27 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid27,
                    Name = "Stand-LivingRoom",
                    Description = "Human2 Stand In LivingRoom",
                    Delay = 200,
                    EndPossibility = 100
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid25,
                    ActionAggregateId = guid14,
                    //NumberOfActions = 1,
                    Possibility = 70,
                    Delay = 350
                }
            );

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid25,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "LivingRoom"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid25,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Stand"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid25,
                    ResultType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ResultCaseType = ResultCaseEnum.Position,
                    ResultCaseChange = "LivingRoom"
                },
                new ActionResult
                {
                    ActionAggregateId = guid25,
                    ResultType = CaseStudyEnum.ItemState,
                    CaseStudy = "AirConditioner3",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "On"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid26,
                    ActionAggregateId = guid25,
                    //NumberOfActions = 1,
                    Possibility = 10,
                    Delay = 200
                },
                new NextAction
                {
                    Id = guid15,
                    ActionAggregateId = guid25,
                    //NumberOfActions = 1,
                    Possibility = 90,
                    Delay = 200
                }
            );
            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid26,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "LivingRoom"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid26,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Stand"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid26,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "AirConditioner3",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "On"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid26,
                    ResultType = CaseStudyEnum.HumanFeelToDegree,
                    CaseStudy = "Human2",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Cold"
                },
                new ActionResult
                {
                    ActionAggregateId = guid26,
                    ResultType = CaseStudyEnum.ItemMetaData,
                    CaseStudy = "AirConditioner3-Temperature",
                    ResultCaseType = ResultCaseEnum.Decrease,
                    ResultCaseChange = "5-15"
                },
                new ActionResult
                {
                    ActionAggregateId = guid26,
                    ResultType = CaseStudyEnum.Environment,
                    CaseStudy = "Degree",
                    ResultCaseType = ResultCaseEnum.Decrease,
                    ResultCaseChange = "7"
                }
            );

            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid27,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "LivingRoom"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid27,
                    ConditionType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.StateIsNot,
                    ConditionCaseExpectation = "Stand"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid27,
                    ResultType = CaseStudyEnum.HumanBodyStatus,
                    CaseStudy = "Human2",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Stand"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid25,
                    ActionAggregateId = guid27,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 200
                }
            );
            #endregion

            #endregion



            #region GoToKitchen
            var guid101 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid101,
                    Name = "Move-Corridor-LivingRoom",
                    Description = "Move to corridor via livingroom",
                    Delay = 2400,
                    EndPossibility = 50
                }
            );

            var guid102 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid102,
                    Name = "Open-Kitchen-Door",
                    Description = "Open door of the kitchen",
                    Delay = 1100,
                    EndPossibility = 100
                }
            );

            var guid103 = Guid.NewGuid();
            modelBuilder.Entity<ActionAggregate>().HasData(
                new ActionAggregate
                {
                    Id = guid103,
                    Name = "Move-Kitchen-Corridor",
                    Description = "Move to kitchen form corridor",
                    Delay = 500,
                    EndPossibility = 100
                }
            );

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid101,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "LivingRoom"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid101,
                    ResultType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ResultCaseType = ResultCaseEnum.Position,
                    ResultCaseChange = "Corridor"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid102,
                    ActionAggregateId = guid101,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 200
                }
            );
            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid102,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "Corridor"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid102,
                    ResultType = CaseStudyEnum.ItemState,
                    CaseStudy = "KitchenDoor",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Open"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid103,
                    ActionAggregateId = guid102,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 300
                }
            );

            #endregion

            #region One ActionAggregate

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid103,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "Corridor"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid103,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "KitchenDoor",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Open"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid103,
                    ResultType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ResultCaseType = ResultCaseEnum.Position,
                    ResultCaseChange = "Kitchen"
                }
            );
            #endregion

            #endregion

            #region SafeBox

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid201,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "Corridor"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid201,
                    ResultType = CaseStudyEnum.ItemState,
                    CaseStudy = "SafeBox",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Open"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid202,
                    ActionAggregateId = guid201,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 1800
                }
            );

            modelBuilder.Entity<ActionCondition>().HasData(
                new ActionCondition
                {
                    ActionAggregateId = guid202,
                    ConditionType = CaseStudyEnum.HumanPosition,
                    CaseStudy = "Human2",
                    ConditionCaseType = ConditionCaseEnum.IsIn,
                    ConditionCaseExpectation = "Corridor"
                },
                new ActionCondition
                {
                    ActionAggregateId = guid202,
                    ConditionType = CaseStudyEnum.ItemState,
                    CaseStudy = "SafeBox",
                    ConditionCaseType = ConditionCaseEnum.StateIs,
                    ConditionCaseExpectation = "Open"
                }
            );

            modelBuilder.Entity<ActionResult>().HasData(
                new ActionResult
                {
                    ActionAggregateId = guid202,
                    ResultType = CaseStudyEnum.ItemState,
                    CaseStudy = "SafeBox",
                    ResultCaseType = ResultCaseEnum.State,
                    ResultCaseChange = "Close"
                }
            );

            modelBuilder.Entity<NextAction>().HasData(
                new NextAction
                {
                    Id = guid101,
                    ActionAggregateId = guid202,
                    //NumberOfActions = 1,
                    Possibility = 100,
                    Delay = 600
                }
            );

            #endregion

            #endregion

        }

    }

}