using AutoMapper;
using NotasWorkshop.Model.Contexts.NotasWorkshop;
using NotasWorkshop.Model.Entities;
using NotasWorkshop.Model.Repositories;
using NotasWorkshop.Model.UnitOfWorks;
using NotasWorkshop.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Services.Services
{
    public class BarberProfileService : EntityCRUDService<BarberProfile, BarberProfileDto>, IBarberProfileService
    {
        private readonly IBarberProfileRepository _barberprofileRepository;
        public BarberProfileService(IMapper mapper,
            IUnitOfWork<INotasWorkshopDbContext> uow,
            IBarberProfileRepository barberprofileRepository) : base(mapper, uow)
        {
            _barberprofileRepository = barberprofileRepository;
        }
        public BarberProfile CreateBarber(BarberProfile barber)
        {
            _barberprofileRepository.CreateBarber(barber);
            return barber;
        }

        public BarberProfile DeleteBarber(BarberProfile barber)
        {
            _barberprofileRepository.DeleteBarber(barber);
            return barber;
        }
        public List<BarberProfile> GetAllBarbers()
        {
            var barbers = _barberprofileRepository.GetAllBarbers();

            return barbers;
        }
    }
}
