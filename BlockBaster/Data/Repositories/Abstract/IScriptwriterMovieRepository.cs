using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface IScriptwriterMovieRepository
    {
        IQueryable<ScriptwriterMovie> GetScriptwriterMovies();
        ScriptwriterMovie GetScriptwriterMovieById(int id);
        void SaveScriptwriterMovie(ScriptwriterMovie entity);
        void DeleteScriptwriterMovie(int id);
    }
}
