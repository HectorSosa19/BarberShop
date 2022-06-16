using AutoMapper;
using NotasWorkshop.Model.Contexts.NotasWorkshop;
using NotasWorkshop.Model.Entities;
using NotasWorkshop.Model.UnitOfWorks;
using NotasWorkshop.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Services.Services
{
    public interface ITypeHairCutService : IEntityCRUDService<TypeHairCut, TypeHairCutDto>
    {

    }
    public class TypeHairCutService : EntityCRUDService<TypeHairCut, TypeHairCutDto>, ITypeHairCutService
    {
        public TypeHairCutService(IMapper mapper, IUnitOfWork<INotasWorkshopDbContext> uow)
           : base(mapper, uow)
        {
        }
    }
}
