using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface IGenreRepository
    {
        IQueryable<Genre> GetGenres();
        Genre GetGenreById(int id);
        Genre GetGenreByName(string name);
        void SaveGenre(Genre entity);
        void DeleteGenre(int id);
    }
}
