﻿// <auto-generated />
using System;
using AspWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspWebAPI.Data.Migrations
{
    [DbContext(typeof(_DBContext))]
    partial class _DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspWebAPI.Data.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Creater_at")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("NickName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Creater_at = new DateTimeOffset(new DateTime(2022, 11, 9, 12, 9, 9, 378, DateTimeKind.Unspecified).AddTicks(5948), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Younes",
                            LastName = "ERRAJI",
                            Password = "1234560",
                            Username = "younes-erraji"
                        });
                });

            modelBuilder.Entity("AspWebAPI.Data.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Author_ID")
                        .HasColumnType("int")
                        .HasColumnName("Author");

                    b.Property<string>("CoverUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Created_at")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<float?>("Rate")
                        .HasMaxLength(5)
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Author_ID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author_ID = 1,
                            Created_at = new DateTimeOffset(new DateTime(2022, 11, 9, 12, 9, 9, 389, DateTimeKind.Unspecified).AddTicks(5118), new TimeSpan(0, 1, 0, 0, 0)),
                            Price = 17.8m,
                            Title = "Rich Dad Poor Dad"
                        });
                });

            modelBuilder.Entity("AspWebAPI.Data.Models.BookReader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("ExperationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("Read_at")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ReaderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReaderId");

                    b.ToTable("BooksReaders");
                });

            modelBuilder.Entity("AspWebAPI.Data.Models.Reader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Created_at")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Mail")
                        .IsUnique();

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("AspWebAPI.Data.Models.Book", b =>
                {
                    b.HasOne("AspWebAPI.Data.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("Author_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("AspWebAPI.Data.Models.BookReader", b =>
                {
                    b.HasOne("AspWebAPI.Data.Models.Book", "Book")
                        .WithMany("BookReaders")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspWebAPI.Data.Models.Reader", "Reader")
                        .WithMany("ReaderBooks")
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("AspWebAPI.Data.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("AspWebAPI.Data.Models.Book", b =>
                {
                    b.Navigation("BookReaders");
                });

            modelBuilder.Entity("AspWebAPI.Data.Models.Reader", b =>
                {
                    b.Navigation("ReaderBooks");
                });
#pragma warning restore 612, 618
        }
    }
}