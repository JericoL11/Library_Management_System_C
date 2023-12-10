﻿// <auto-generated />
using System;
using Library_Management_System_C.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library_Management_System_C.Migrations
{
    [DbContext(typeof(Library_Management_System_CContext))]
    [Migration("20231210083337_BorrowersRecordsDetails")]
    partial class BorrowersRecordsDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Library_Management_System_C.Models.Books", b =>
                {
                    b.Property<int>("bookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookId"), 1L, 1);

                    b.Property<string>("author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateAdded")
                        .HasColumnType("datetime2");

                    b.HasKey("bookId");

                    b.HasIndex("categoryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library_Management_System_C.Models.Borrower", b =>
                {
                    b.Property<int>("borrowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("borrowerId"), 1L, 1);

                    b.Property<string>("borrower_Course")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("borrower_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("borrower_PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("borrower_fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("borrower_lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date_registered")
                        .HasColumnType("datetime2");

                    b.HasKey("borrowerId");

                    b.ToTable("Borrower");
                });

            modelBuilder.Entity("Library_Management_System_C.Models.Category_Book", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoryId"), 1L, 1);

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryId");

                    b.ToTable("Category_Book");
                });

            modelBuilder.Entity("Library_Management_System_C.Models.Details", b =>
                {
                    b.Property<int>("details_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("details_id"), 1L, 1);

                    b.Property<int>("books_id")
                        .HasColumnType("int");

                    b.Property<int>("record_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("return_date")
                        .HasColumnType("datetime2");

                    b.HasKey("details_id");

                    b.HasIndex("books_id");

                    b.HasIndex("record_id");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("Library_Management_System_C.Models.Records", b =>
                {
                    b.Property<int>("record_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("record_id"), 1L, 1);

                    b.Property<int>("borrowerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("due_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("librarianId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("transac_date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("record_id");

                    b.HasIndex("borrowerId");

                    b.HasIndex("librarianId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("Library_Management_System_C.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("confirm_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Library_Management_System_C.Models.Books", b =>
                {
                    b.HasOne("Library_Management_System_C.Models.Category_Book", "book_category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book_category");
                });

            modelBuilder.Entity("Library_Management_System_C.Models.Details", b =>
                {
                    b.HasOne("Library_Management_System_C.Models.Books", "FK_books_id")
                        .WithMany()
                        .HasForeignKey("books_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_Management_System_C.Models.Records", "FK_record_id")
                        .WithMany()
                        .HasForeignKey("record_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_books_id");

                    b.Navigation("FK_record_id");
                });

            modelBuilder.Entity("Library_Management_System_C.Models.Records", b =>
                {
                    b.HasOne("Library_Management_System_C.Models.Borrower", "FK_borrower")
                        .WithMany()
                        .HasForeignKey("borrowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_Management_System_C.Models.User", "FK_librarian")
                        .WithMany()
                        .HasForeignKey("librarianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_borrower");

                    b.Navigation("FK_librarian");
                });
#pragma warning restore 612, 618
        }
    }
}
