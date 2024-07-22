using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface IProducerRepository
    {
        IQueryable<Producer> GetProducers();
        Producer GetProducerById(int id);
        Producer GetProducerByName(string name);
        void SaveProducer(Producer entity);
        void DeleteProducer(int id);
    }
}
