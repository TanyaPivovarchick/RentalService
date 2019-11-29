﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentalService.DAL;

namespace RentalService.DAL.Migrations
{
    [DbContext(typeof(RentalServiceContext))]
    partial class RentalServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RentalService.DAL.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Toyota"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bentley"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Nissan"
                        });
                });

            modelBuilder.Entity("RentalService.DAL.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<double>("FuelConsumption")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            FuelConsumption = 9.0,
                            Name = "BMW X6",
                            SeatCount = 5
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            FuelConsumption = 7.9000000000000004,
                            Name = "BMW X7",
                            SeatCount = 5
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            FuelConsumption = 9.0999999999999996,
                            Name = "BMW X7",
                            SeatCount = 7
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 3,
                            FuelConsumption = 6.0,
                            Name = "Audi Q7",
                            SeatCount = 5
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 5,
                            FuelConsumption = 18.0,
                            Name = "Nissan Armada",
                            SeatCount = 8
                        });
                });

            modelBuilder.Entity("RentalService.DAL.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Barcelona"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Madrid"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            Name = "Alicante"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            Name = "Lisbon"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 2,
                            Name = "Porto"
                        });
                });

            modelBuilder.Entity("RentalService.DAL.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "ES",
                            Name = "Spain"
                        },
                        new
                        {
                            Id = 2,
                            Code = "PT",
                            Name = "Portugal"
                        });
                });

            modelBuilder.Entity("RentalService.DAL.Entities.RentalCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RentalCompanies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Europcar"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sixt"
                        });
                });

            modelBuilder.Entity("RentalService.DAL.Entities.RentalPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyId");

                    b.ToTable("RentalPoints");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "GV DE LES CORTS CATALANES 680",
                            CityId = 1,
                            CompanyId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "AVDA HISPANIDAD S/N LLEGADAS",
                            CityId = 2,
                            CompanyId = 1
                        },
                        new
                        {
                            Id = 3,
                            Address = "ED.GARE DO ORIENTE,LG.G-206",
                            CityId = 4,
                            CompanyId = 1
                        },
                        new
                        {
                            Id = 4,
                            Address = "Plaza de la Puerta del Mar,3",
                            CityId = 3,
                            CompanyId = 2
                        },
                        new
                        {
                            Id = 5,
                            Address = "Rua do Barreiro 65",
                            CityId = 5,
                            CompanyId = 2
                        });
                });

            modelBuilder.Entity("RentalService.DAL.Entities.RentalPointCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("RentalPointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("RentalPointId");

                    b.ToTable("RentalPointCars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 1,
                            Cost = 15.0,
                            Count = 10,
                            RentalPointId = 1
                        },
                        new
                        {
                            Id = 2,
                            CarId = 1,
                            Cost = 20.0,
                            Count = 15,
                            RentalPointId = 2
                        },
                        new
                        {
                            Id = 3,
                            CarId = 2,
                            Cost = 31.0,
                            Count = 23,
                            RentalPointId = 2
                        },
                        new
                        {
                            Id = 4,
                            CarId = 2,
                            Cost = 26.0,
                            Count = 17,
                            RentalPointId = 3
                        },
                        new
                        {
                            Id = 5,
                            CarId = 2,
                            Cost = 28.0,
                            Count = 11,
                            RentalPointId = 4
                        },
                        new
                        {
                            Id = 6,
                            CarId = 3,
                            Cost = 35.0,
                            Count = 5,
                            RentalPointId = 5
                        },
                        new
                        {
                            Id = 7,
                            CarId = 4,
                            Cost = 25.0,
                            Count = 7,
                            RentalPointId = 5
                        },
                        new
                        {
                            Id = 8,
                            CarId = 5,
                            Cost = 40.0,
                            Count = 9,
                            RentalPointId = 5
                        });
                });

            modelBuilder.Entity("RentalService.DAL.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("KeyReceiptTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("KeyReturnTime")
                        .HasColumnType("time");

                    b.Property<int>("RentalPointCarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RentalPointCarId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RentalService.DAL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("RentalService.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            Password = "123456",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "user@gmail.com",
                            Password = "123456",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("RentalService.DAL.Entities.Car", b =>
                {
                    b.HasOne("RentalService.DAL.Entities.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentalService.DAL.Entities.City", b =>
                {
                    b.HasOne("RentalService.DAL.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentalService.DAL.Entities.RentalPoint", b =>
                {
                    b.HasOne("RentalService.DAL.Entities.City", "City")
                        .WithMany("Points")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalService.DAL.Entities.RentalCompany", "Company")
                        .WithMany("Points")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentalService.DAL.Entities.RentalPointCar", b =>
                {
                    b.HasOne("RentalService.DAL.Entities.Car", "Car")
                        .WithMany("RentalPointCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalService.DAL.Entities.RentalPoint", "RentalPoint")
                        .WithMany("RentalPointCars")
                        .HasForeignKey("RentalPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentalService.DAL.Entities.Reservation", b =>
                {
                    b.HasOne("RentalService.DAL.Entities.RentalPointCar", "RentalPointCar")
                        .WithMany("Reservations")
                        .HasForeignKey("RentalPointCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalService.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentalService.DAL.Entities.User", b =>
                {
                    b.HasOne("RentalService.DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
