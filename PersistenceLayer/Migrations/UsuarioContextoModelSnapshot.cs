﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersistenceLayer.Context;

#nullable disable

namespace PersistenceLayer.Migrations
{
    [DbContext(typeof(UsuarioContexto))]
    partial class UsuarioContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("PersistenceLayer.Dao.UsuarioDao", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<int>("Cargo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Cpf");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
