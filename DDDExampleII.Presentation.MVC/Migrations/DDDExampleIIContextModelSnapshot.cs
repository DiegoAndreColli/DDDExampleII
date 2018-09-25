﻿// <auto-generated />
using System;
using DDDExampleII.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DDDExampleII.Presentation.MVC.Migrations
{
    [DbContext(typeof(DDDExampleIIContext))]
    partial class DDDExampleIIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DDDExampleII.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance");

                    b.Property<string>("Code");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DDDExampleII.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("DDDExampleII.Domain.Entities.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("DDDExampleII.Domain.Entities.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId");

                    b.Property<int?>("FromId");

                    b.Property<int?>("ToId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Transfer");
                });

            modelBuilder.Entity("DDDExampleII.Domain.Entities.Entity", b =>
                {
                    b.HasOne("DDDExampleII.Domain.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("DDDExampleII.Domain.Entities.Transfer", b =>
                {
                    b.HasOne("DDDExampleII.Domain.Entities.Book")
                        .WithMany("Transfers")
                        .HasForeignKey("BookId");

                    b.HasOne("DDDExampleII.Domain.Entities.Entity", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("DDDExampleII.Domain.Entities.Entity", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });
#pragma warning restore 612, 618
        }
    }
}
