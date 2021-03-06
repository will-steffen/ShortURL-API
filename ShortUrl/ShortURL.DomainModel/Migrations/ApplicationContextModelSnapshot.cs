﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShortURL.DomainModel;

namespace ShortURL.DomainModel.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ShortURL.DomainModel.Entities.Click", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("dt_created");

                    b.Property<long>("IdShortUrl")
                        .HasColumnName("id_short_url");

                    b.Property<string>("Ip")
                        .HasColumnName("txt_ip");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("dt_updated");

                    b.HasKey("Id");

                    b.HasIndex("IdShortUrl");

                    b.ToTable("click");
                });

            modelBuilder.Entity("ShortURL.DomainModel.Entities.ShortUrl", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .HasColumnName("txt_code");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("dt_created");

                    b.Property<long>("IdUser")
                        .HasColumnName("id_user");

                    b.Property<string>("Original")
                        .HasColumnName("txt_original");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("dt_updated");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("short_url");
                });

            modelBuilder.Entity("ShortURL.DomainModel.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("dt_created");

                    b.Property<string>("Ip")
                        .HasColumnName("txt_ip");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("dt_updated");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("ShortURL.DomainModel.Entities.Click", b =>
                {
                    b.HasOne("ShortURL.DomainModel.Entities.ShortUrl", "ShortUrl")
                        .WithMany("ClickList")
                        .HasForeignKey("IdShortUrl")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShortURL.DomainModel.Entities.ShortUrl", b =>
                {
                    b.HasOne("ShortURL.DomainModel.Entities.User", "User")
                        .WithMany("ShortUrlList")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
