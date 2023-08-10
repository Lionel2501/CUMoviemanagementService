using Microsoft.EntityFrameworkCore;
using MovieManagement.DataAccess.Context;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Implementation
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieManagementDbContext context) : base(context)
        {
             
        }

        /*
        public bool RemoveMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if(movie != null) { 
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        */
    }
}
