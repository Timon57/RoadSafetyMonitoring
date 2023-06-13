using System.ComponentModel.DataAnnotations;

namespace RoadSafety.Models.DTO
{
    public class RegisterRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}
