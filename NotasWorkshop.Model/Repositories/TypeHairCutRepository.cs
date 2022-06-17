using NotasWorkshop.Model.Contexts.NotasWorkshop;
using NotasWorkshop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Model.Repositories
{
    public class TypeHairCutRepository : ITypeHairCutRepository
    {
        public static List<TypeHairCut> TypeHairCuts = new List<TypeHairCut>()
        {

        };
        private readonly NotasWorkshopDbContext _typehaircutDbContext;

        public TypeHairCutRepository(NotasWorkshopDbContext typehaircutDbContext)
        {
            _typehaircutDbContext = typehaircutDbContext;
        }

        public TypeHairCut CreateHaircut(TypeHairCut typehaircut)
        {
            _typehaircutDbContext.TypeHairCuts.Add(typehaircut);
            _typehaircutDbContext.SaveChanges();
            return typehaircut;
        }

        public TypeHairCut DeleteHaircut(TypeHairCut typehaircut)
        {
            _typehaircutDbContext.TypeHairCuts.Remove(typehaircut);
            _typehaircutDbContext.SaveChanges();

            return null;
        }

        public List<TypeHairCut> GetAllHaircuts()
        {
            return _typehaircutDbContext.TypeHairCuts.ToList();
        }

    }
}
