using AutoMapper;
using NotasWorkshop.Model.Contexts.NotasWorkshop;
using NotasWorkshop.Model.Entities;
using NotasWorkshop.Model.Repositories;
using NotasWorkshop.Model.UnitOfWorks;
using NotasWorkshop.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Services.Services
{
    public class TypeHairCutService : EntityCRUDService<TypeHairCut, TypeHairCutDto>, ITypeHairCutService
    {
        private readonly ITypeHairCutRepository _typeHairCutRepository;
        public TypeHairCutService(IMapper mapper, IUnitOfWork<INotasWorkshopDbContext> uow , ITypeHairCutRepository typeHairCutRepository)
           : base(mapper, uow)
        {
            _typeHairCutRepository = typeHairCutRepository;
        }
        public TypeHairCut CreateHaircut(TypeHairCut typehaircut)
        {

            _typeHairCutRepository.CreateHaircut(typehaircut);

            return typehaircut;
        }

        public TypeHairCut DeleteHaircut(TypeHairCut typehaircut)
        {
            _typeHairCutRepository.DeleteHaircut(typehaircut);
            return typehaircut;
        }
        public List<TypeHairCut> GetAllHaircuts()
        {
            var typehaircuts = _typeHairCutRepository.GetAllHaircuts();

            return typehaircuts;
        }
    }
}
