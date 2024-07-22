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
    public class EFMovieCountryRepository: IMovieCountryRepository
    {
        private readonly AppDbContext context;
        public EFMovieCountryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<MovieCountry> GetMovieCountries()
        {
            return context.MovieCountries;
        }
        public MovieCountry GetMovieCountryById(int id)
        {
            return context.MovieCountries.FirstOrDefault(x => x.Id == id);
        }
        public void SaveMovieCountry(MovieCountry entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteMovieCountry(int id)
        {
            context.MovieCountries.Remove(new MovieCountry() { Id = id });
            context.SaveChanges();
        }
    }
}
