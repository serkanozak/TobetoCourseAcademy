using AutoMapper;
using Business.Dtos.Requests.CourseRequest;
using Business.Dtos.Responses.CourseResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Mapping
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CreateCourseRequest, Course>();
            CreateMap<Course, CreatedCourseResponse>();

            CreateMap<Course, GetListedCourseResponse>();
            CreateMap<Paginate<Course>, Paginate<GetListedCourseResponse>>();
        }
    }
}
