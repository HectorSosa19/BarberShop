using NotasWorkshop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Model.Repositories
{
    public interface ITypeHairCutRepository
    {
        List<TypeHairCut> GetAllHaircuts();

        TypeHairCut CreateHaircut(TypeHairCut typehaircut);

        TypeHairCut DeleteHaircut(TypeHairCut typehaircut);
    }
}
