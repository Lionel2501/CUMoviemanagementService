using Microsoft.EntityFrameworkCore;
using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Context
{
    public class MovieManagementDbContext : DbContext
    {
        public MovieManagementDbContext(DbContextOptions<MovieManagementDbContext> options) : base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Biography> Biography { get; set; } 
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FirstName = "Chuck", LastName = "Norris" }, 
                new Actor { Id = 2, FirstName = "Jane", LastName = "Doe"},
                new Actor { Id = 3, FirstName = "Van", LastName = "Damme" }
            );

        }
    }
}
