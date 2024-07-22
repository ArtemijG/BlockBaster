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
    public class EFSubscriptionRepository: ISubscriptionRepository
    {
        private readonly AppDbContext context;
        public EFSubscriptionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Subscription> GetSubscriptions()
        {
            return context.Subscriptions;
        }
        public Subscription GetSubscriptionById(int id)
        {
            return context.Subscriptions.FirstOrDefault(x => x.Id == id);
        }
        public void SaveSubscription(Subscription entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteSubscription(int id)
        {
            context.Subscriptions.Remove(new Subscription() { Id = id });
            context.SaveChanges();
        }
    }
}
