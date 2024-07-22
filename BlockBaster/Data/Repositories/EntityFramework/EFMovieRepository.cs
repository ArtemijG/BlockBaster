using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockBaster.Data.Entities;
using BlockBaster.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BlockBaster.Data.Repositories.EntityFramework
{
    public class EFMovieRepository: IMovieRepository
    {
        private readonly AppDbContext context;
        public EFMovieRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Movie> GetMovies()
        {
            return context.Movies;
        }
        public Movie GetMovieById(int id)
        {
            return context.Movies.FirstOrDefault(x => x.Id == id);
        }
        public Movie GetMovieByName(string name)
        {
            return context.Movies.FirstOrDefault(x => x.Name == name);
        }
        public void SaveMovie(Movie entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteMovie(int id)
        {
            context.Movies.Remove(new Movie() { Id = id });
            context.SaveChanges();
        }
    }
}
