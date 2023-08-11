using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Domain.Repository
{
    public interface IActorRepository : IGenericRepository<Actor>
    {
        IEnumerable<Actor> GetActorsDBRelation();

        IQueryable<Actor> GetActorsLinq();

        List<Actor> GetWithAutoMapper();
    }
}
