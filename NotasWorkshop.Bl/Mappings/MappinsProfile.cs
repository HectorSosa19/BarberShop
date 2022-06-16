using AutoMapper;
using NotasWorkshop.Bl.Extensions;
using NotasWorkshop.Model.Entities;

namespace NotasWorkshop.Bl.Mappings
{
    public class MappinsProfile : Profile
    {
        public MappinsProfile()
        {
            this._CreateMap_WithConventions_FromAssemblies<Appointment,AppointmentDto>();
            this._CreateMap_WithConventions_FromAssemblies<BarberProfile,BarberProfileDto>();
            this._CreateMap_WithConventions_FromAssemblies<Invoice,InvoiceDto>();
            this._CreateMap_WithConventions_FromAssemblies<Review,ReviewDto>();
            this._CreateMap_WithConventions_FromAssemblies<TypeHairCut,TypeHairCutDto>();
            this._CreateMap_WithConventions_FromAssemblies<User,UserDto>();
        }
    }
}
