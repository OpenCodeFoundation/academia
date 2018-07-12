﻿// <auto-generated />
using Academia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Academia.Infrastructure.Migrations
{
    [DbContext(typeof(AcademiaContext))]
    [Migration("20180502062856_add-classinfo")]
    partial class addclassinfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Academia.Core.Entities.ClassInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassName");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("ClassInfos");
                });

            modelBuilder.Entity("Academia.Core.Entities.Institute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Institutes");
                });
#pragma warning restore 612, 618
        }
    }
}
