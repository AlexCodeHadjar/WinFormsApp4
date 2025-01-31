﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp4.Models;

public partial class CUsersuserDesktopNewDataBasedbContext : DbContext
{
    public CUsersuserDesktopNewDataBasedbContext(DbContextOptions<CUsersuserDesktopNewDataBasedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Yahct> Yahcts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.Id, "IX_User_Id").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Yahct>(entity =>
        {
            entity.ToTable("Yahct");

            entity.HasIndex(e => e.Id, "IX_Yahct_Id").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Colour).IsRequired();
            entity.Property(e => e.DopEquipment).IsRequired();
            entity.Property(e => e.Machta).IsRequired();
            entity.Property(e => e.Material).IsRequired();
            entity.Property(e => e.Model).IsRequired();
            entity.Property(e => e.Name).IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}