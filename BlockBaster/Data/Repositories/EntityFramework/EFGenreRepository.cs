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
    public class EFGenreRepository: IGenreRepository
    {
        private readonly AppDbContext context;
        public EFGenreRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Genre> GetGenres()
        {
            return context.Genres;
        }
        public Genre GetGenreById(int id)
        {
            return context.Genres.FirstOrDefault(x => x.Id == id);
        }
        public Genre GetGenreByName(string name)
        {
            return context.Genres.FirstOrDefault(x => x.Name == name);
        }
        public void SaveGenre(Genre entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteGenre(int id)
        {
            context.Genres.Remove(new Genre() { Id = id });
            context.SaveChanges();
        }
    }
}
