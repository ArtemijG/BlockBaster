using BlockBaster.Data.Entities;
using BlockBaster.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.EntityFramework
{
    public class EFCountryRepository: ICountryRepository
    {
        private readonly AppDbContext context;
        public EFCountryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Country> GetCountries()
        {
            return context.Countries;
        }
        public Country GetCountryById(int id)
        {
            return context.Countries.FirstOrDefault(x => x.Id == id);
        }
        public Country GetCountryByName(string name)
        {
            return context.Countries.FirstOrDefault(x => x.Name == name);
        }
        public void SaveCountry(Country entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteCountry(int id)
        {
            context.Countries.Remove(new Country() { Id = id });
            context.SaveChanges();
        }
    }
}
