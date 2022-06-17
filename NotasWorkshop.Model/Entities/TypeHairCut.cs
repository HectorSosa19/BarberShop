using NotasWorkshop.Core.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Model.Entities
{
    public class TypeHairCut : BaseEntity
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Duration { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public ICollection<Appointment> Appointments { get; set; } 
        public Invoice Invoices { get; set; }
    }
}
