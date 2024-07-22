using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface IMovieCountryRepository
    {
        IQueryable<MovieCountry> GetMovieCountries();
        MovieCountry GetMovieCountryById(int id);
        void SaveMovieCountry(MovieCountry entity);
        void DeleteMovieCountry(int id);
    }
}
