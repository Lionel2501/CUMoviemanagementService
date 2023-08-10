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
    public class BiographyRepository : GenericRepository<Biography>, IBiographyRepository
    {
        public BiographyRepository(MovieManagementDbContext context) : base(context)
        {
            
        }
        public bool UpdateBiography(Biography biography)
        {
            int id = biography.Id;
            var _biography = _context.Biography.FirstOrDefault(x => x.Id == id);

            if (_biography != null)
            {
                _biography.ActorId = biography.ActorId;
                _biography.Description = biography.Description;

                _context.SaveChanges();
                return true;
            } else            
            {
                return false;
            }   
        }

    }
}
