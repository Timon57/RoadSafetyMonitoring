using System.ComponentModel.DataAnnotations;

namespace RoadSafety.Models.DTO
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Condition { get; set; }
    }
}
