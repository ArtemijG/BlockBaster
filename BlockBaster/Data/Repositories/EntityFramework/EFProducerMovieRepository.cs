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
    public class EFProducerMovieRepository: IProducerMovieRepository
    {
        private readonly AppDbContext context;
        public EFProducerMovieRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ProducerMovie> GetProducerMovies()
        {
            return context.ProducerMovies;
        }
        public ProducerMovie GetProducerMovieById(int id)
        {
            return context.ProducerMovies.FirstOrDefault(x => x.Id == id);
        }
        public void SaveProducerMovie(ProducerMovie entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteProducerMovie(int id)
        {
            context.ProducerMovies.Remove(new ProducerMovie() { Id = id });
            context.SaveChanges();
        }
    }
}
