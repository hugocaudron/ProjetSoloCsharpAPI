using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using ProjetSoloCsharp.API.Admins.Models;
using ProjetSoloCsharp.API.Salaries;
using ProjetSoloCsharp.API.Service.Models;
using ProjetSoloCsharp.API.Sites.Models;

namespace ProjetSoloCsharp.Shared.Data;

// Définition du contexte de base de données pour Entity Framework Core
public partial class ApplicationDbContext : DbContext
{
    // Constructeur sans paramètre, utilisé principalement par Entity Framework
    public ApplicationDbContext()
    {
    }

    // Constructeur permettant d'injecter les options de configuration
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Définition des DbSet qui représentent les tables de la base de données
    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Salarié> Salariés { get; set; }
    public virtual DbSet<Service> Services { get; set; }
    public virtual DbSet<Site> Sites { get; set; }

    // Configuration de la connexion à la base de données
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")
                                  ?? throw new InvalidOperationException(
                                      "Connection string 'DATABASE_CONNECTION_STRING' not found.");

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    // Configuration des entités et de leurs propriétés
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        // Configuration de l'entité Admin
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY"); 

            entity.ToTable("Admin"); 

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Email).HasColumnType("text");
            entity.Property(e => e.PasswordHash)
                .HasColumnType("text")
                .HasColumnName("Password_Hash");
            entity.Property(e => e.PasswordSalt)
                .HasMaxLength(255)
                .HasColumnName("Password_Salt");
        });

        // Configuration de l'entité Salarié
        modelBuilder.Entity<Salarié>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Email).HasColumnType("text");
            entity.Property(e => e.IdServices)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Services");
            entity.Property(e => e.IdSite)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Site");
            entity.Property(e => e.Nom).HasMaxLength(255);
            entity.Property(e => e.Prénom).HasMaxLength(255);
            entity.Property(e => e.TelFixe)
                .HasColumnType("int(11)")
                .HasColumnName("Tel_Fixe");
            entity.Property(e => e.TelPortable)
                .HasColumnType("int(11)")
                .HasColumnName("Tel_Portable");
        });

        // Configuration de l'entité Service
        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Service1)
                .HasColumnType("text")
                .HasColumnName("Service");
        });

        // Configuration de l'entité Site
        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Ville).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
