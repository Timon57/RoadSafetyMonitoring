using System.ComponentModel.DataAnnotations;

namespace RoadSafety.Models.DTO
{
    public class AddFeedbackDto
    {
        [Required]
        public string Location { get; set; }
        [Required]
        public string Condition { get; set; }
    }

}

