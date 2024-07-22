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
    public class EFProducerRepository: IProducerRepository
    {
        private readonly AppDbContext context;
        public EFProducerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Producer> GetProducers()
        {
            return context.Producers;
        }
        public Producer GetProducerById(int id)
        {
            return context.Producers.FirstOrDefault(x => x.Id == id);
        }
        public Producer GetProducerByName(string name)
        {
            return context.Producers.FirstOrDefault(x => x.Name == name);
        }
        public void SaveProducer(Producer entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteProducer(int id)
        {
            context.Producers.Remove(new Producer() { Id = id });
            context.SaveChanges();
        }
    }
}
