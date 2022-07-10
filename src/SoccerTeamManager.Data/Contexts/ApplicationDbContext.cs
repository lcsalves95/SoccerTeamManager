﻿using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Game> Games { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
