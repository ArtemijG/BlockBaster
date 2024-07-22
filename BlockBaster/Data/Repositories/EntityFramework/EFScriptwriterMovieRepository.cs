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
    public class EFScriptwriterMovieRepository: IScriptwriterMovieRepository
    {
        private readonly AppDbContext context;
        public EFScriptwriterMovieRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ScriptwriterMovie> GetScriptwriterMovies()
        {
            return context.ScriptwriterMovies;
        }
        public ScriptwriterMovie GetScriptwriterMovieById(int id)
        {
            return context.ScriptwriterMovies.FirstOrDefault(x => x.Id == id);
        }
        public void SaveScriptwriterMovie(ScriptwriterMovie entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteScriptwriterMovie(int id)
        {
            context.ScriptwriterMovies.Remove(new ScriptwriterMovie() { Id = id });
            context.SaveChanges();
        }
    }
}
