using NotasWorkshop.Core.BaseModel.BaseEntity;
using NotasWorkshop.Core.BaseModel.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Model.Entities
{
    public class AppointmentDto : BaseEntityDto
    {
        public DateTime DateHour { get; set; }
        public bool IsCancelled { get; set; }
        public int IdBarberProfile { get; set; }
        public int IdTypeHairCut { get; set; }
        public int IdUser { get; set; }
    }
}
