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
    public class EFMovieGenreRepository: IMovieGenreRepository
    {
        private readonly AppDbContext context;
        public EFMovieGenreRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<MovieGenre> GetMovieGenres()
        {
            return context.MovieGenres;
        }
        public MovieGenre GetMovieGenreById(int id)
        {
            return context.MovieGenres.FirstOrDefault(x => x.Id == id);
        }
        public MovieGenre GetMovieGenreByIdGenre(int id)
        {
            return context.MovieGenres.FirstOrDefault(x => x.Id == id);
        }
        public void SaveMovieGenre(MovieGenre entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteMovieGenre(int id)
        {
            context.MovieGenres.Remove(new MovieGenre() { Id = id });
            context.SaveChanges();
        }
    }
}
