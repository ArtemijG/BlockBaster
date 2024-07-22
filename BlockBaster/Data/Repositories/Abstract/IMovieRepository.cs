using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GetMovies();
        Movie GetMovieById(int id);
        Movie GetMovieByName(string name);
        void SaveMovie(Movie entity);
        void DeleteMovie(int id);
    }
}
