using NotasWorkshop.Core.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Model.Entities
{
    public class Appointment : BaseEntity
    {
        public DateTime DateHour { get; set; }
        public bool IsCancelled { get; set; }
        public int IdBarberProfile { get; set; }
        [ForeignKey("IdBarberProfile")]
        public BarberProfile BarberProfiles { get; set; }
        public int IdTypeHairCut { get; set; }
        [ForeignKey("IdTypeHairCut")]
        public TypeHairCut TypeHairCuts { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User Users { get; set; }
    }
}
