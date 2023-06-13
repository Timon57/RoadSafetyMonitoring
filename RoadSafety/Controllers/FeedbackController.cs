using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoadSafety.Data;
using RoadSafety.Models.Domain;
using RoadSafety.Models.DTO;
using RoadSafety.Repository;

namespace RoadSafety.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly RoadDbContext dbContext;
        private readonly IFeedbackRepository feedbackRepository;
        private readonly IMapper mapper;

        public FeedbackController(RoadDbContext dbContext,IFeedbackRepository feedbackRepository,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.feedbackRepository = feedbackRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var feedbacks = await feedbackRepository.GetAllAsync();
            return Ok(feedbacks);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var feedback = await feedbackRepository.GetByIdAsync(id);
            if(feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddFeedbackDto addFeedbackDto)
        {
            if (ModelState.IsValid)
            {
                var feedbackDomainModel = mapper.Map<Feedback>(addFeedbackDto);

                await feedbackRepository.CreateAsync(feedbackDomainModel);
                await dbContext.SaveChangesAsync();

                var feedbackDto = mapper.Map<FeedbackDto>(feedbackDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = feedbackDto.Id }, feedbackDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
