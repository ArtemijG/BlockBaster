using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface IActorRepository
    {
        IQueryable<Actor> GetActors();
        Actor GetActorById(int id);
        Actor GetActorByName(string name);
        void SaveActor(Actor entity);
        void DeleteActor(int id);
    }
}
