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
    public class ReviewController : BaseController<Review,ReviewDto>
    {
        public ReviewController(IReviewService ReviewService,
       IValidatorFactory validationFactory,
       IMapper mapper) : base(ReviewService, validationFactory, mapper)
        {
        }
    }
}
