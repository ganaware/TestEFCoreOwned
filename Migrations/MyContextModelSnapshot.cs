﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestEFCoreOwned.Models;

namespace TestEFCoreOwned.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("TestEFCoreOwned.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("TestEFCoreOwned.Models.Book", b =>
                {
                    b.OwnsOne("TestEFCoreOwned.Models.Info", "ChineseInfo", b1 =>
                        {
                            b1.Property<string>("Author");

                            b1.Property<int?>("BookId")
                                .IsRequired();

                            b1.Property<string>("Title");

                            b1.ToTable("Books");

                            b1.HasOne("TestEFCoreOwned.Models.Book")
                                .WithOne("ChineseInfo")
                                .HasForeignKey("TestEFCoreOwned.Models.Info", "BookId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TestEFCoreOwned.Models.Info", "EnglishInfo", b1 =>
                        {
                            b1.Property<string>("Author")
                                .HasMaxLength(100);

                            b1.Property<int>("BookId");

                            b1.Property<string>("Memo");

                            b1.Property<string>("Title");

                            b1.ToTable("Books");

                            b1.HasOne("TestEFCoreOwned.Models.Book")
                                .WithOne("EnglishInfo")
                                .HasForeignKey("TestEFCoreOwned.Models.Info", "BookId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TestEFCoreOwned.Models.Info", "JapaneseInfo", b1 =>
                        {
                            b1.Property<string>("Author");

                            b1.Property<int>("BookId");

                            b1.Property<string>("Title");

                            b1.ToTable("Books");

                            b1.HasOne("TestEFCoreOwned.Models.Book")
                                .WithOne("JapaneseInfo")
                                .HasForeignKey("TestEFCoreOwned.Models.Info", "BookId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}