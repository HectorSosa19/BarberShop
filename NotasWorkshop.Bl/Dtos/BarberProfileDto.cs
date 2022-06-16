using Microsoft.AspNetCore.Http;
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
    public class BarberProfileDto : BaseEntityDto
    {
        public int Experience { get; set; }
        public int SeatNum { get; set; }
        public bool IsAvailable { get; set; }
        public IFormFile Photo { get; set; }
        public int IdUser { get; set; }
    }
}
