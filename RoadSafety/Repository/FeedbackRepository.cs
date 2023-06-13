using Microsoft.EntityFrameworkCore;
using RoadSafety.Data;
using RoadSafety.Models.Domain;

namespace RoadSafety.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly RoadDbContext dbContext;

        public FeedbackRepository(RoadDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Feedback> CreateAsync(Feedback feedback)
        {
            await dbContext.feedbacks.AddAsync(feedback);
            await dbContext.SaveChangesAsync();
            return feedback;
        }

        public async Task<List<Feedback>> GetAllAsync()
        {
            return await dbContext.feedbacks.ToListAsync();
        }

        public async Task<Feedback?> GetByIdAsync(int id)
        {
            return await dbContext.feedbacks.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
