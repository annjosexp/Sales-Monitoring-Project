using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace SalesMonitoringAPI.Models
{
    public partial class SalesMonitoringDBContext : DbContext
    {
        public SalesMonitoringDBContext()
        {
        }

        public SalesMonitoringDBContext(DbContextOptions<SalesMonitoringDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblVisit> TblVisit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)

                if (!optionsBuilder.IsConfigured)
                {
                    IConfigurationRoot configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json")
                       .Build();
                    var connectionString = configuration.GetConnectionString("Constr");
                    optionsBuilder.UseSqlServer(connectionString);
                }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__TblEmplo__AF2DBB99C741A673");

                entity.Property(e => e.EmpAddress)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__TblEmploy__Login__4316F928");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK__TblUser__4DDA281829158AEC");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVisit>(entity =>
            {
                entity.HasKey(e => e.VisitId)
                    .HasName("PK__TblVisit__4D3AA1DE6E0E30B5");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InterestProduct)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Vdescription)
                    .HasColumnName("VDescription")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VisitDateTime).HasColumnType("datetime");

                entity.Property(e => e.VisitSubject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TblVisit)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__TblVisit__EmpId__45F365D3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
