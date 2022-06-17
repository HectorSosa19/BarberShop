using NotasWorkshop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Services.Services
{
    public interface IBarberProfileService
    {
        List<BarberProfile> GetAllBarbers();

        BarberProfile CreateBarber(BarberProfile barber);

        BarberProfile DeleteBarber(BarberProfile IdBarberProfile);

    }
}
