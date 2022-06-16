using NotasWorkshop.Core.BaseModel.BaseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NotasWorkshop.Core.BaseModel.BaseEntityDto
{
    public interface IBaseEntityDto : IBaseDto
    {
        [JsonIgnore]
        string CreatedBy { get; set; }
        [JsonIgnore]
        string UpdatedBy { get; set; }
    }
}
