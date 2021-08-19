using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NezamMVCOneLayer.Models;
 

namespace NezamMVCOneLayer.DataAccess.Data
{
    public partial class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Candid> Candids { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Elect> Elects { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<test> tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candid>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.Candids)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Candids_Cities");
            });

            modelBuilder.Entity<Elect>(entity =>
            {
                entity.HasKey(e => new { e.CandidId, e.MemberId });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Candid)
                    .WithMany(p => p.Elects)
                    .HasForeignKey(d => d.CandidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Elects_Condids");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Elects)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Elects_Members");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Members_Cities");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.FieldId)
                    .HasConstraintName("FK_Members_Fields");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
