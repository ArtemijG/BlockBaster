using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface IScriptwriterRepository
    {
        IQueryable<Scriptwriter> GetScriptwriters();
        Scriptwriter GetScriptwriterById(int id);
        Scriptwriter GetScriptwriterByName(string name);
        void SaveScriptwriter(Scriptwriter entity);
        void DeleteScriptwriter(int id);
    }
}
