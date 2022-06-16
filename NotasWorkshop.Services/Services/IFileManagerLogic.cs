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
        Task<string> Upload(BarberWork model);
        Task<byte[]> Read(string fileName);
    }
}
