using NotasWorkshop.Core.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Model.Entities
{
    public class Review : BaseEntity
    {
        public int Rating { get; set; }
        public string Comments { get; set; }
        public int IdBarberProfile { get; set; }
        [ForeignKey("IdBarberProfile")]
        public BarberProfile BarberProfiles { get; set; }

    }
}
