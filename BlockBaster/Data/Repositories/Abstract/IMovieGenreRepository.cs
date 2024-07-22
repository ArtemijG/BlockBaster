using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface IMovieGenreRepository
    {
        IQueryable<MovieGenre> GetMovieGenres();
        MovieGenre GetMovieGenreById(int id);
        public MovieGenre GetMovieGenreByIdGenre(int id);
        void SaveMovieGenre(MovieGenre entity);
        void DeleteMovieGenre(int id);
    }
}
