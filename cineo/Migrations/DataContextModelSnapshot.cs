﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cineo.Data;

namespace cineo.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("cineo.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ImdbScore")
                        .HasColumnType("float");

                    b.Property<double>("MetacriticScore")
                        .HasColumnType("float");

                    b.Property<string>("Production")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RottenTomatoesScore")
                        .HasColumnType("float");

                    b.Property<string>("SmallImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfProduction")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("cineo.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SeatMap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("cineo.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Col")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("cineo.Models.Shows", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAndTimeOfShows")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hall")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Movie")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Subtitles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Movie");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("cineo.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreationDate")
                        .HasColumnType("int");

                    b.Property<int?>("Hall")
                        .HasColumnType("int");

                    b.Property<int?>("Seance")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("Users")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Hall");

                    b.HasIndex("Seance");

                    b.HasIndex("Users");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("cineo.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Permission")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("cineo.Models.Seat", b =>
                {
                    b.HasOne("cineo.Models.Room", "Room")
                        .WithMany("Seats")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("cineo.Models.Shows", b =>
                {
                    b.HasOne("cineo.Models.Movie", "Movie_Id")
                        .WithMany()
                        .HasForeignKey("Movie");
                });

            modelBuilder.Entity("cineo.Models.Ticket", b =>
                {
                    b.HasOne("cineo.Models.Shows", "Hall_id")
                        .WithMany()
                        .HasForeignKey("Hall");

                    b.HasOne("cineo.Models.Shows", "Seance_id")
                        .WithMany()
                        .HasForeignKey("Seance");

                    b.HasOne("cineo.Models.User", "Users_id")
                        .WithMany()
                        .HasForeignKey("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
