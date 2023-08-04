using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IActorRepository Actor { get; }
        IMovieRepository Movie { get; }
        IBiographyRepository Biography { get; }
        IGenreRepository Genre { get; }

        int Save();

    }
}
