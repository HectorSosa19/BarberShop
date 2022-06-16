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
    public class InvoiceDto : BaseEntityDto
    {
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public string Details { get; set; }
        public int IdTypeHairCut { get; set; }
    }
}
