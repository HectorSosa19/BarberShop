using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotasWorkshop.Api.Controllers;
using NotasWorkshop.Model.Contexts.NotasWorkshop;
using NotasWorkshop.Model.Entities;
using NotasWorkshop.Services.Services;

namespace NotasWorkshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberProfileController : ControllerBase
    {
        public static BarberProfile barber = new BarberProfile();
        private readonly IConfiguration _configuration;
        private readonly IBarberProfileService _service;
        private readonly IHttpContextAccessor _accessor;
        private readonly IFileManagerLogic _imageService;
        private readonly NotasWorkshopDbContext Context;

        public BarberProfileController(IConfiguration configuration, IBarberProfileService service, IHttpContextAccessor accessor, NotasWorkshopDbContext dataContext, IFileManagerLogic img)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accessor = accessor;
            _imageService = img;
        }
        [HttpGet]
        public async Task<ActionResult<List<BarberProfile>>> Get()
        {
            return Ok(await Context.BarberProfiles.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BarberProfile>> Get(int id)
        {
            var barber = await Context.BarberProfiles.FindAsync(id);
            if (barber == null)
                return BadRequest("Barber not found");
            return Ok(barber);
        }

        [HttpPost]
        public async Task<ActionResult<List<BarberProfile>>> AddBarbers([FromForm] BarberProfileDto request)
        {
            barber.Id = request.Id.Value;
            barber.SeatNum = request.SeatNum;
            barber.ImageFile = await _imageService.Upload(request.ImageFile);
            barber.Experience = request.Experience;
            barber.IsAvailable = request.IsAvailable;
            barber.IdUser = request.IdUser;

            PostBarber(barber);

            return Ok(barber);
        }

        private BarberProfile PostBarber(BarberProfile barber)
        {

            var barberFromService = _service.CreateBarber(barber);
            return barberFromService;
        }

        [HttpPut]
        public async Task<ActionResult<List<BarberProfile>>> UpdateBarbers([FromForm] BarberProfileDto request)
        {
            var barber = await Context.BarberProfiles.FindAsync(request.Id);
            if (barber == null)
                return BadRequest("Barber not found.");
            barber.SeatNum = request.SeatNum;
            barber.ImageFile = await _imageService.Upload(request.ImageFile);
            barber.Experience = request.Experience;
            barber.IsAvailable = request.IsAvailable;
            barber.IdUser = request.IdUser;

            await Context.SaveChangesAsync();

            return Ok(await Context.BarberProfiles.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<BarberProfile>>> Delete(int id)
        {
            var barber = await Context.BarberProfiles.FindAsync(id);
            if (barber == null)
                return BadRequest("Barber not found");

            Context.BarberProfiles.Remove(barber);
            await Context.SaveChangesAsync();
            return Ok(await Context.BarberProfiles.ToListAsync());
        }
    }
}
