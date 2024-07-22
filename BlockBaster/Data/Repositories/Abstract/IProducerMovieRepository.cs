using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface IProducerMovieRepository
    {
        IQueryable<ProducerMovie> GetProducerMovies();
        ProducerMovie GetProducerMovieById(int id);
        void SaveProducerMovie(ProducerMovie entity);
        void DeleteProducerMovie(int id);
    }
}
