using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NotasWorkshop.Core.BaseModel.BaseDto
{
    public interface IBaseDto
    {
        int? Id { get; set; }
        [JsonIgnore]
        bool Deleted { get; set; }
    }
}
