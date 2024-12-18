﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservationNew.Db.Contexts;

#nullable disable

namespace RestaurantReservationNew.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    partial class RestaurantReservationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "1234567890"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "jane.smith@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            PhoneNumber = "2345678901"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "bob.brown@example.com",
                            FirstName = "Bob",
                            LastName = "Brown",
                            PhoneNumber = "3456789012"
                        },
                        new
                        {
                            CustomerId = 4,
                            Email = "alice.white@example.com",
                            FirstName = "Alice",
                            LastName = "White",
                            PhoneNumber = "4567890123"
                        },
                        new
                        {
                            CustomerId = 5,
                            Email = "tom.black@example.com",
                            FirstName = "Tom",
                            LastName = "Black",
                            PhoneNumber = "5678901234"
                        });
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            FirstName = "Michael",
                            LastName = "Johnson",
                            Position = "Manager",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            FirstName = "Emily",
                            LastName = "Davis",
                            Position = "Chef",
                            RestaurantId = 2
                        },
                        new
                        {
                            EmployeeId = 3,
                            FirstName = "Chris",
                            LastName = "Wilson",
                            Position = "Waiter",
                            RestaurantId = 3
                        },
                        new
                        {
                            EmployeeId = 4,
                            FirstName = "Anna",
                            LastName = "Brown",
                            Position = "Host",
                            RestaurantId = 4
                        },
                        new
                        {
                            EmployeeId = 5,
                            FirstName = "David",
                            LastName = "Clark",
                            Position = "Manager",
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.MenuItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Description = "Delicious beef burger",
                            Name = "Burger",
                            Price = 8.99m,
                            RestaurantId = 1
                        },
                        new
                        {
                            ItemId = 2,
                            Description = "Classic Italian pizza",
                            Name = "Pizza Margherita",
                            Price = 10.99m,
                            RestaurantId = 2
                        },
                        new
                        {
                            ItemId = 3,
                            Description = "Fresh sushi rolls",
                            Name = "Sushi Roll",
                            Price = 12.99m,
                            RestaurantId = 3
                        },
                        new
                        {
                            ItemId = 4,
                            Description = "Juicy steak",
                            Name = "Steak",
                            Price = 15.99m,
                            RestaurantId = 4
                        },
                        new
                        {
                            ItemId = 5,
                            Description = "Healthy vegan salad",
                            Name = "Vegan Salad",
                            Price = 9.99m,
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            EmployeeId = 1,
                            OrderDate = new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 1,
                            TotalAmount = 45.99m
                        },
                        new
                        {
                            OrderId = 2,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 2,
                            TotalAmount = 20.99m
                        },
                        new
                        {
                            OrderId = 3,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 3,
                            TotalAmount = 70.50m
                        },
                        new
                        {
                            OrderId = 4,
                            EmployeeId = 4,
                            OrderDate = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 4,
                            TotalAmount = 90.00m
                        },
                        new
                        {
                            OrderId = 5,
                            EmployeeId = 5,
                            OrderDate = new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 5,
                            TotalAmount = 120.75m
                        });
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            ItemId = 1,
                            OrderId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 2,
                            ItemId = 2,
                            OrderId = 2,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 3,
                            ItemId = 3,
                            OrderId = 3,
                            Quantity = 3
                        },
                        new
                        {
                            OrderItemId = 4,
                            ItemId = 4,
                            OrderId = 4,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 5,
                            ItemId = 5,
                            OrderId = 5,
                            Quantity = 4
                        });
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CustomerId = 1,
                            PartySize = 4,
                            ReservationDate = new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RestaurantId = 1,
                            TableId = 1
                        },
                        new
                        {
                            ReservationId = 2,
                            CustomerId = 2,
                            PartySize = 2,
                            ReservationDate = new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RestaurantId = 2,
                            TableId = 3
                        },
                        new
                        {
                            ReservationId = 3,
                            CustomerId = 3,
                            PartySize = 6,
                            ReservationDate = new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RestaurantId = 3,
                            TableId = 4
                        },
                        new
                        {
                            ReservationId = 4,
                            CustomerId = 4,
                            PartySize = 8,
                            ReservationDate = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RestaurantId = 4,
                            TableId = 5
                        },
                        new
                        {
                            ReservationId = 5,
                            CustomerId = 5,
                            PartySize = 10,
                            ReservationDate = new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RestaurantId = 5,
                            TableId = 2
                        });
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            RestaurantId = 1,
                            Address = "123 Main Street",
                            Name = "The Gourmet Spot",
                            OpeningHours = "9 AM - 10 PM",
                            PhoneNumber = "9876543210"
                        },
                        new
                        {
                            RestaurantId = 2,
                            Address = "456 Elm Street",
                            Name = "Pizza Palace",
                            OpeningHours = "11 AM - 11 PM",
                            PhoneNumber = "8765432109"
                        },
                        new
                        {
                            RestaurantId = 3,
                            Address = "789 Oak Street",
                            Name = "Sushi Central",
                            OpeningHours = "12 PM - 9 PM",
                            PhoneNumber = "7654321098"
                        },
                        new
                        {
                            RestaurantId = 4,
                            Address = "321 Pine Street",
                            Name = "Steakhouse Deluxe",
                            OpeningHours = "10 AM - 10 PM",
                            PhoneNumber = "6543210987"
                        },
                        new
                        {
                            RestaurantId = 5,
                            Address = "654 Maple Street",
                            Name = "Vegan Haven",
                            OpeningHours = "8 AM - 8 PM",
                            PhoneNumber = "5432109876"
                        });
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Capacity = 4,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 2,
                            Capacity = 2,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 3,
                            Capacity = 6,
                            RestaurantId = 2
                        },
                        new
                        {
                            TableId = 4,
                            Capacity = 8,
                            RestaurantId = 3
                        },
                        new
                        {
                            TableId = 5,
                            Capacity = 10,
                            RestaurantId = 4
                        });
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Employee", b =>
                {
                    b.HasOne("RestaurantReservationNew.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.MenuItem", b =>
                {
                    b.HasOne("RestaurantReservationNew.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Order", b =>
                {
                    b.HasOne("RestaurantReservationNew.Db.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservationNew.Db.Entities.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.OrderItem", b =>
                {
                    b.HasOne("RestaurantReservationNew.Db.Entities.MenuItem", "MenuItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantReservationNew.Db.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Reservation", b =>
                {
                    b.HasOne("RestaurantReservationNew.Db.Entities.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservationNew.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservationNew.Db.Entities.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId");

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Table", b =>
                {
                    b.HasOne("RestaurantReservationNew.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.MenuItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Restaurant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("RestaurantReservationNew.Db.Entities.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
