using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface IActorMovieRepository
    {
        IQueryable<ActorMovie> GetActorMovies();
        ActorMovie GetActorMovieById(int id);
        void SaveActorMovie(ActorMovie entity);
        void DeleteActorMovie(int id);
    }
}
