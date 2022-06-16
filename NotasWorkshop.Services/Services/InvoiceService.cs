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
    public interface IInvoiceService : IEntityCRUDService<Invoice, InvoiceDto>
    {
        
    }
    public class InvoiceService : EntityCRUDService<Invoice, InvoiceDto>, IInvoiceService
    {
        public InvoiceService(IMapper mapper, IUnitOfWork<INotasWorkshopDbContext> uow) : base(mapper, uow)
        {

        }
    }
}
