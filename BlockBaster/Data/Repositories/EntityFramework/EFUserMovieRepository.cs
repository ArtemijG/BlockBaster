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
    public class EFUserMovieRepository: IUserMovieRepository
    {
        private readonly AppDbContext context;
        public EFUserMovieRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<UserMovie> GetUserMovies()
        {
            return context.UserMovies;
        }
        public UserMovie GetUserMovieById(int id)
        {
            return context.UserMovies.FirstOrDefault(x => x.Id == id);
        }
        public void SaveUserMovie(UserMovie entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteUserMovie(int id)
        {
            context.UserMovies.Remove(new UserMovie() { Id = id });
            context.SaveChanges();
        }
    }
}
