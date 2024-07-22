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
    public class EFActorMovieRepository: IActorMovieRepository
    {
        private readonly AppDbContext context;
        public EFActorMovieRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ActorMovie> GetActorMovies()
        {
            return context.ActorMovies;
        }
        public ActorMovie GetActorMovieById(int id)
        {
            return context.ActorMovies.FirstOrDefault(x => x.Id == id);
        }
        public void SaveActorMovie(ActorMovie entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteActorMovie(int id)
        {
            context.ActorMovies.Remove(new ActorMovie() { Id = id });
            context.SaveChanges();
        }
    }
}
