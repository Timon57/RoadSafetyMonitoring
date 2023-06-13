using RoadSafety.Models.Domain;

namespace RoadSafety.Repository
{
    public interface IFeedbackRepository
    {
        Task<List<Feedback>> GetAllAsync();
        Task<Feedback?> GetByIdAsync(int id);

        Task<Feedback> CreateAsync(Feedback feedback);
    }
}
