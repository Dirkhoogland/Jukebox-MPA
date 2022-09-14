using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Jukebox_MPA_ASP.NET.Models.Database
{
    public partial class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genres> Genres { get; set; } = null!;
        public virtual DbSet<Playlistname> Playlistname { get; set; } = null!;
        public virtual DbSet<Playlists> Playlists { get; set; } = null!;
        public virtual DbSet<Queue> Queue { get; set; } = null!;
        public virtual DbSet<Songs> Songs { get; set; } = null!;
        public virtual DbSet<Users> Users { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genres>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Genre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Playlistname>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Playlistname1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Playlistname");

                entity.Property(e => e.User)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Playlists>(entity =>
            {
                entity.Property(e => e.Song)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.User)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.PlaylistNavigation)
                    .WithMany(p => p.Playlists)
                    .HasForeignKey(d => d.Playlist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Playlists_Playlistname");
            });

            modelBuilder.Entity<Queue>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Songname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.User)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Songs>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Author)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Genre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
