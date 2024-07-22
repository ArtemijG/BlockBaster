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
    public class EFScriptwriterRepository: IScriptwriterRepository
    {
        private readonly AppDbContext context;
        public EFScriptwriterRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Scriptwriter> GetScriptwriters()
        {
            return context.Scriptwriters;
        }
        public Scriptwriter GetScriptwriterById(int id)
        {
            return context.Scriptwriters.FirstOrDefault(x => x.Id == id);
        }
        public Scriptwriter GetScriptwriterByName(string name)
        {
            return context.Scriptwriters.FirstOrDefault(x => x.Name == name);
        }
        public void SaveScriptwriter(Scriptwriter entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteScriptwriter(int id)
        {
            context.Scriptwriters.Remove(new Scriptwriter() { Id = id });
            context.SaveChanges();
        }
    }
}
