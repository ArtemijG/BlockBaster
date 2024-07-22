using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface ICountryRepository
    {
        IQueryable<Country> GetCountries();
        Country GetCountryById(int id);
        Country GetCountryByName(string name);
        void SaveCountry(Country entity);
        void DeleteCountry(int id);
    }
}
