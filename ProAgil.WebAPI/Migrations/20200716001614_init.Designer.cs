﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProAgil.WebAPI.Data;

namespace ProAgil.WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200716001614_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("ProAgil.WebAPI.Model.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountPeople")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lot")
                        .HasColumnType("TEXT");

                    b.Property<string>("Theme")
                        .HasColumnType("TEXT");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
