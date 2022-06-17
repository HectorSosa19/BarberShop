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
    public class TypeHairCutDto : BaseEntityDto
    {
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
        public string Duration { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
