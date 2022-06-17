using NotasWorkshop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Services.Services
{
    public interface ITypeHairCutService
    {
        List<TypeHairCut> GetAllHaircuts();

        TypeHairCut CreateHaircut(TypeHairCut haircut);

        TypeHairCut DeleteHaircut(TypeHairCut haircut);
    }
}
