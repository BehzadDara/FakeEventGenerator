﻿using FakeEventGenerator.Domain.DTOs;
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

            #region Door
            modelBuilder.Entity<Item>().HasData(
               new Item
               {
                   Name = "Door",
                   Description = "House Door",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   CoordinateX = 55,
                   CoordinateY = 0,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Door",
                   Description = "LivingRoom Door",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   CoordinateX = 55,
                   CoordinateY = 30,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Door",
                   Description = "Kitchen Door",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   CoordinateX = 15,
                   CoordinateY = 30,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Door",
                   Description = "Bathroom Door",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   CoordinateX = 90,
                   CoordinateY = 30,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Door",
                   Description = "Bedroom1 Door",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   CoordinateX = 25,
                   CoordinateY = 50,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Door",
                   Description = "Bedroom2 Door",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   CoordinateX = 75,
                   CoordinateY = 50,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Door",
                   Description = "Balcony Door1",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   CoordinateX = 25,
                   CoordinateY = 80,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Door",
                   Description = "Balcony Door1",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   CoordinateX = 75,
                   CoordinateY = 80,
                   IsMovable = false
               },
            #endregion

            #region Window
               new Item
               {
                   Name = "Window",
                   Description = "Bedroom1 Window",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   CoordinateX = 0,
                   CoordinateY = 65,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Window",
                   Description = "Bedroom2 Window",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   CoordinateX = 100,
                   CoordinateY = 65,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Window",
                   Description = "Balcony Window",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   CoordinateX = 50,
                   CoordinateY = 100,
                   IsMovable = false
               },
            #endregion

            #region Bedroom Items
               new Item
               {
                   Name = "Bed",
                   Description = "Bedroom1 Bed",
                   Type = ItemEnum.UseWithCapacity,
                   State = ItemState.NotFull,
                   CoordinateX = 40,
                   CoordinateY = 65,
                   IsMovable = false
               },
               new Item
               {
                   Name = "AirConditioner1",
                   Description = "Bedroom1 AirConditioner",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   CoordinateX = 49,
                   CoordinateY = 55,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Computer",
                   Description = "Bedroom1 Computer",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   CoordinateX = 10,
                   CoordinateY = 79,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Chair11",
                   Description = "Bedroom1 Chair",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   CoordinateX = 10,
                   CoordinateY = 75,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Lamp1",
                   Description = "Bedroom1 Lamp",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   CoordinateX = 25,
                   CoordinateY = 65,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new LampMetaData
                   {
                       Severity = 20
                   })
               },

               new Item
               {
                   Name = "Bed",
                   Description = "Bedroom2 Bed",
                   Type = ItemEnum.UseWithCapacity,
                   State = ItemState.NotFull,
                   CoordinateX = 60,
                   CoordinateY = 65,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new AirConditionerMetaData
                   {
                       Tempreture = 20,
                       Speed = 10
                   })
               },
               new Item
               {
                   Name = "AirConditioner2",
                   Description = "Bedroom2 AirConditioner",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   CoordinateX = 51,
                   CoordinateY = 55,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new AirConditionerMetaData
                   {
                       Tempreture = 20,
                       Speed = 10
                   })
               },
               new Item
               {
                   Name = "Laptop",
                   Description = "Bedroom2 Laptop",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   CoordinateX = 90,
                   CoordinateY = 79,
                   IsMovable = true,
                   MetaData = JsonSerializer.Serialize(new LaptopMetaData
                   {
                       Charge = 90
                   })
               },
               new Item
               {
                   Name = "Chair21",
                   Description = "Bedroom2 Chair",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   CoordinateX = 90,
                   CoordinateY = 75,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Lamp2",
                   Description = "Bedroom2 Lamp",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   CoordinateX = 75,
                   CoordinateY = 65,
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
                   CoordinateX = 15,
                   CoordinateY = 1,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Refrigerator",
                   Description = "Kitchen Refrigerator",
                   Type = ItemEnum.Openable,
                   State = ItemState.Close,
                   CoordinateX = 1,
                   CoordinateY = 15,
                   IsMovable = false
               },
               new Item
               {
                   Name = "WashingMachine",
                   Description = "Kitchen WashingMachine",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   CoordinateX = 29,
                   CoordinateY = 15,
                   IsMovable = false
               },
               new Item
               {
                   Name = "DishWasher",
                   Description = "Kitchen DishWasher",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   CoordinateX = 25,
                   CoordinateY = 1,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Lamp3",
                   Description = "Kitchen Lamp",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   CoordinateX = 15,
                   CoordinateY = 15,
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
                   CoordinateX = 79,
                   CoordinateY = 15,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new TVMetaData
                   {
                       Channel = 1,
                       Sound = 20
                   })
               },
               new Item
               {
                   Name = "Sofa1",
                   Description = "LivingRoom Sofa1",
                   Type = ItemEnum.UseWithCapacity,
                   State = ItemState.NotFull,
                   CoordinateX = 70,
                   CoordinateY = 20,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Sofa2",
                   Description = "LivingRoom Sofa2",
                   Type = ItemEnum.UseWithCapacity,
                   State = ItemState.NotFull,
                   CoordinateX = 70,
                   CoordinateY = 10,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Sofa3",
                   Description = "LivingRoom Sofa3",
                   Type = ItemEnum.UseWithCapacity,
                   State = ItemState.NotFull,
                   CoordinateX = 60,
                   CoordinateY = 15,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Table",
                   Description = "LivingRoom Table",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   CoordinateX = 40,
                   CoordinateY = 15,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Chair1",
                   Description = "LivingRoom Chair1",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   CoordinateX = 35,
                   CoordinateY = 15,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Chair2",
                   Description = "LivingRoom Chair2",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   CoordinateX = 45,
                   CoordinateY = 15,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Chair3",
                   Description = "LivingRoom Chair3",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   CoordinateX = 40,
                   CoordinateY = 10,
                   IsMovable = false
               },
               new Item
               {
                   Name = "Chair4",
                   Description = "LivingRoom Chair4",
                   Type = ItemEnum.Usable,
                   State = ItemState.NotBeUsing,
                   CoordinateX = 40,
                   CoordinateY = 20,
                   IsMovable = false
               },
               new Item
               {
                   Name = "AirConditioner3",
                   Description = "LivingRoom AirConditioner",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   CoordinateX = 40,
                   CoordinateY = 29,
                   IsMovable = false,
                   MetaData = JsonSerializer.Serialize(new AirConditionerMetaData
                   {
                       Tempreture = 20,
                       Speed = 10
                   })
               },
               new Item
               {
                   Name = "Lamp4",
                   Description = "LivingRoom Lamp",
                   Type = ItemEnum.Electronic,
                   State = ItemState.Off,
                   CoordinateX = 55,
                   CoordinateY = 15,
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
                   CoordinateX = 90,
                   CoordinateY = 15,
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
                   CoordinateX = 50,
                   CoordinateY = 90,
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
                   CoordinateX = 50,
                   CoordinateY = 40,
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
                    CoordinateX = 10,
                    CoordinateY = 74,
                    FeelToDegree = FeelToDegreeEnum.Medium,
                    BodyStatus = BodyStatusEnum.Stand,
                    MentalStatus = MentalStatusEnum.Busy
                },
                new Human
                {
                    Name = "Human2",
                    CoordinateX = 75,
                    CoordinateY = 65,
                    FeelToDegree = FeelToDegreeEnum.Medium,
                    BodyStatus = BodyStatusEnum.Stand,
                    MentalStatus = MentalStatusEnum.Normal
                }
            );

            #endregion
        }
    }
}