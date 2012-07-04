using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Form14242.Web.ViewModels;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;

namespace Form14242.Web.Core
{
    public class Repository : DbContext
    {
        public Repository()
            : base("Form14242")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<Form14242Model> Form14242 { get; set; }
        public DbSet<Preparer> Preparers { get; set; }
        public DbSet<Promoter> Promoters { get; set; }
        public DbSet<Artifact> Artifacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Form14242Model>()
                .HasKey(p => p.ID)
                .ToTable("Form14242", "Store");
            modelBuilder.Entity<Form14242Model>()
                .HasMany(p => p.Preparers);
            modelBuilder.Entity<Form14242Model>()
                .HasMany(p => p.Promoters);
            modelBuilder.Entity<Form14242Model>()
                .HasMany(p => p.Artifacts);
            modelBuilder.Entity<Form14242Model>()
                .Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            modelBuilder.Entity<Preparer>()
                .HasKey(p => p.ID)
                .ToTable("Preparers", "Store");
            modelBuilder.Entity<Preparer>()
                .Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Promoter>()
                .HasKey(p => p.ID)
                .ToTable("Promoters", "Store");
            modelBuilder.Entity<Promoter>()
                .Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Artifact>()
                .HasKey(p => p.ID)
                .ToTable("Artifacts", "Store");
            modelBuilder.Entity<Artifact>()
                .Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // because were using sql ce as a proof of concept, the largest binary field is an image. change this to varbinary when going to sql server
            modelBuilder.Entity<Artifact>()
                .Property(p => p.FileContents).HasColumnType("image").IsMaxLength();
        }
    }
}