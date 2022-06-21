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
    public class TypeHairCutController : ControllerBase
    {
        public static TypeHairCut typehaircut = new TypeHairCut();
        private readonly IConfiguration _configuration;
        private readonly ITypeHairCutService _service;
        private readonly IHttpContextAccessor _accessor;
        private readonly IFileManagerLogic _imageService;
        private readonly NotasWorkshopDbContext Context;
        public TypeHairCutController(IConfiguration configuration, ITypeHairCutService service, IHttpContextAccessor accessor, NotasWorkshopDbContext dataContext, IFileManagerLogic img)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accessor = accessor;
            _imageService = img;
        }
        [HttpGet]
        public async Task<ActionResult<List<TypeHairCut>>> Get()
        {
            return Ok(await Context.TypeHairCuts.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TypeHairCut>> Get(int id)
        {
            var haircut = await Context.TypeHairCuts.FindAsync(id);
            if (haircut == null)
                return BadRequest("Haircut not found");
            return Ok(haircut);
        }

        [HttpPost]
        public async Task<ActionResult<List<TypeHairCut>>> AddHaircuts([FromForm] TypeHairCutDto request)
        {
            typehaircut.Id = request.Id.Value;
            typehaircut.Name = request.Name;
            typehaircut.Photo = await _imageService.Upload(request.Photo);
            typehaircut.Duration = request.Duration;
            typehaircut.Price = request.Price;
            typehaircut.Description = request.Description;

            PostHaircut(typehaircut);

            return Ok(typehaircut);
        }

        private TypeHairCut PostHaircut(TypeHairCut haircut)
        {

            var haircutFromService = _service.CreateHaircut(haircut);
            return haircutFromService;
        }

        [HttpPut]
        public async Task<ActionResult<List<TypeHairCut>>> UpdateHaircuts([FromForm] TypeHairCutDto request)
        {
            var haircut = await Context.TypeHairCuts.FindAsync(request.Id);
            if (haircut == null)
                return BadRequest("Haircut not found.");

            typehaircut.Id = request.Id.Value;
            typehaircut.Name = request.Name;
            typehaircut.Photo = await _imageService.Upload(request.Photo);
            typehaircut.Duration = request.Duration;
            typehaircut.Price = request.Price;
            typehaircut.Description = request.Description;



            await Context.SaveChangesAsync();

            return Ok(await Context.TypeHairCuts.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TypeHairCut>>> Delete(int id)
        {
            var haircut = await Context.TypeHairCuts.FindAsync(id);
            if (haircut == null)
                return BadRequest("Haircut not found");

            Context.TypeHairCuts.Remove(haircut);
            await Context.SaveChangesAsync();
            return Ok(await Context.TypeHairCuts.ToListAsync());
        }
    }
}
