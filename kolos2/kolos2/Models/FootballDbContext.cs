using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Models
{
    public class FootballDbContext : DbContext
    {
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Championship_Team> Championship_Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Player_Team> Player_Teams { get; set; }
        public DbSet<Team> Teams { get; set; }

        public FootballDbContext()
        {

        }
        public FootballDbContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Championship>(opt =>
            {
                opt.HasKey(p => p.IdChampionship);
                opt.Property(p => p.IdChampionship)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.OfficialName)
                .HasMaxLength(100)
                .IsRequired();

                opt.HasMany(p => p.Championship_Teams)
                .WithOne(p => p.Championship)
                .HasForeignKey(p => p.IdChampionship);
            });

            modelBuilder.Entity<Championship_Team>(opt =>
            {
                opt.HasKey(p => new { p.IdChampionship, p.IdTeam });
              
            });

            modelBuilder.Entity<Team>(opt =>
            {
                opt.HasKey(p => p.IdTeam);
                opt.Property(p => p.IdTeam)
                .ValueGeneratedOnAdd();

                opt.HasMany(p => p.Championship_Teams)
               .WithOne(p => p.Team)
               .HasForeignKey(p => p.IdTeam);

                opt.HasMany(p => p.Player_Teams)
               .WithOne(p => p.Team)
               .HasForeignKey(p => p.IdTeam);

            });

            modelBuilder.Entity<Player_Team>(opt =>
            {
                opt.HasKey(p => new { p.IdPlayer, p.IdTeam });

                opt.Property(p => p.Comment)
                .HasMaxLength(300);
             

            });
            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasKey(p => p.IdPlayer);
                opt.Property(p => p.IdPlayer)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.FirstName)
               .HasMaxLength(30)
               .IsRequired();

                opt.Property(p => p.LastName)
               .HasMaxLength(50)
               .IsRequired();

                opt.Property(p => p.DateOfBirth)
               .IsRequired();

               opt.HasMany(p => p.Player_Teams)
              .WithOne(p => p.Player)
              .HasForeignKey(p => p.IdPlayer);


            });
        }
    }
}
