using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostTest.Core.Entities;

namespace PostTest.Core.Data
{
    public class DbInitializer
    {
        public static void Initialize(PostDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Members.Any())
            {
                return;
            }

            var member1 = new Member
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Patronymic = "Ivanovich",
                Address = "Moscow"
            };

            var member2 = new Member
            {
                FirstName = "Petr",
                LastName = "Petrov",
                Patronymic = "Petrovich",
                Address = "Bryansk"
            };

            var parcel1 = new Parcel
            {
                Weight = 1000,
                Recipient = member1,
                Sender = member2,
                Inventory = "Many-many things"
            };

            var parcel2 = new Parcel
            {
                Weight = 2000,
                Recipient = member2,
                Sender = member1,
                Inventory = "Very few things"
            };

            context.Parcels.Add(parcel1);
            context.Parcels.Add(parcel2);

            context.SaveChanges();
        }
    }
}
