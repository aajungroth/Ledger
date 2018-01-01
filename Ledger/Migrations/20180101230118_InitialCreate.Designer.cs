﻿// <auto-generated />
using Ledger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Ledger.Migrations
{
    [DbContext(typeof(LedgerContext))]
    [Migration("20180101230118_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Ledger.Models.AuthorClass", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Ledger.Models.BookClass", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ID");

                    b.Property<string>("ISBN");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("Title");

                    b.HasKey("AuthorID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Ledger.Models.ReviewClass", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int>("ID");

                    b.Property<string>("ReviewerName");

                    b.HasKey("BookID");

                    b.ToTable("Review");
                });
#pragma warning restore 612, 618
        }
    }
}
