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

            modelBuilder.Entity("ShortURL.DomainModel.Entities.ShortUrl", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .HasColumnName("txt_code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("dt_created");

                    b.Property<string>("Name")
                        .HasColumnName("txt_original");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("dt_updated");

                    b.HasKey("Id");

                    b.ToTable("short_url");
                });
#pragma warning restore 612, 618
        }
    }
}
