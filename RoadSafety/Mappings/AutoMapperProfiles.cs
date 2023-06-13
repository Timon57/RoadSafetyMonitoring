using AutoMapper;
using RoadSafety.Models.Domain;
using RoadSafety.Models.DTO;

namespace RoadSafety.Mappings
{
    public class AutoMapperProfiles:Profile

    {
        public AutoMapperProfiles() 
        {
            CreateMap<Feedback, FeedbackDto>().ReverseMap();
            CreateMap<AddFeedbackDto, Feedback>().ReverseMap();
        }
       
    }
}
