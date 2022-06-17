using Microsoft.AspNetCore.Http;
using NotasWorkshop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Services.Services
{
    public interface IFileManagerLogic
    {
        public Task<string> Upload(IFormFile model);
    }
}
