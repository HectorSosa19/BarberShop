using NotasWorkshop.Model.Contexts.NotasWorkshop;
using NotasWorkshop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Model.Repositories
{
    public class BarberProfileRepository : IBarberProfileRepository
    {
        public static List<BarberProfile> BarberProfiles = new List<BarberProfile>()
        {

        };
        private readonly NotasWorkshopDbContext _DbContext;

        public BarberProfileRepository(NotasWorkshopDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public BarberProfile CreateBarber(BarberProfile barber)
        {
            _DbContext.BarberProfiles.Add(barber);
            _DbContext.SaveChanges();
            return barber;
        }

        public BarberProfile DeleteBarber(BarberProfile barber)
        {
            _DbContext.BarberProfiles.Remove(barber);
            _DbContext.SaveChanges();

            return null;
        }

        public List<BarberProfile> GetAllBarbers()
        {
            return _DbContext.BarberProfiles.ToList();
        }

    }
}
