using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotasWorkshop.Api.Controllers;
using NotasWorkshop.Model.Entities;
using NotasWorkshop.Services.Services;

namespace NotasWorkshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : BaseController<Appointment, AppointmentDto>
    {
        public AppointmentController(IAppointmentService AppointmentService,
       IValidatorFactory validationFactory,
       IMapper mapper) : base(AppointmentService, validationFactory, mapper)
        {
        }
    }
}
