﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _9p2.Models;

#nullable disable

namespace _9p2.Migrations
{
    [DbContext(typeof(mydb))]
    [Migration("20240501121421_login")]
    partial class login
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_9p2.Models.tbl_login", b =>
                {
                    b.Property<int>("login_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("login_id"));

                    b.Property<string>("login_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("login_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("login_pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("login_id");

                    b.ToTable("logins");
                });
#pragma warning restore 612, 618
        }
    }
}
