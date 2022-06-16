using AutoMapper;
using NotasWorkshop.Model.Contexts.NotasWorkshop;
using NotasWorkshop.Model.Entities;
using NotasWorkshop.Model.UnitOfWorks;
using NotasWorkshop.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Services.Services
{
    public interface IAppointmentService : IEntityCRUDService<Appointment, AppointmentDto>
    {

    }
    public class AppointmentService : EntityCRUDService<Appointment, AppointmentDto>, IAppointmentService
    {
        public AppointmentService(IMapper mapper, IUnitOfWork<INotasWorkshopDbContext> uow) : base(mapper, uow)
        {

        }

    }
}
