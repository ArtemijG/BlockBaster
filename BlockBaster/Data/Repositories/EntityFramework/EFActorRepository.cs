using BlockBaster.Data.Entities;
using BlockBaster.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories
{
    public class EFActorRepository:IActorRepository
    {
        private readonly AppDbContext context;
        public EFActorRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Actor> GetActors()
        {
            return context.Actors;
        }
        public Actor GetActorById(int id)
        {
            return context.Actors.FirstOrDefault(x => x.Id == id);
        }
        public Actor GetActorByName(string name)
        {
            return context.Actors.FirstOrDefault(x => x.Name == name);
        }
        public void SaveActor(Actor entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteActor(int id)
        {
            context.Actors.Remove(new Actor() { Id = id });
            context.SaveChanges();
        }
    }
}
