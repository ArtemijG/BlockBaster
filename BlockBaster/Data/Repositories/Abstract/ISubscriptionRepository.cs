using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface ISubscriptionRepository
    {
        IQueryable<Subscription> GetSubscriptions();
        Subscription GetSubscriptionById(int id);
        void SaveSubscription(Subscription entity);
        void DeleteSubscription(int id);
    }
}
