using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
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
        public virtual DbSet<Playlists> Playlists { get; set; } = null!;
        public virtual DbSet<Savedsongs> Savedsongs { get; set; } = null!;
        public virtual DbSet<Songs> Songs { get; set; } = null!;


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Genres>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Genre)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Playlists>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Playlist)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Song)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.User)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Savedsongs>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Song)
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

                entity.Property(e => e.Song)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Songs>().HasData(
            new Songs { Id = 1,  Author = "test", Genre = "Test 1", Song = "testsong" });






            //var testSong = this.Songs.FirstOrDefault(b => b.Url == "http://test.com");

            //this.Songs.Add(new Songs { Id = 2, Author = "test", Genre = "Test 1", Song = "testsong" });


            //this.SaveChanges();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
