using AutoMapper;
using Business.Dtos.Requests.CourseRequest;
using Business.Dtos.Requests.CourseRequests;
using Business.Dtos.Responses.CourseResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Mapping
{
    public class CourseMappingProfiles : Profile
    {
        public CourseMappingProfiles()
        {
            CreateMap<CreateCourseRequest, Course>();
            CreateMap<Course, CreatedCourseResponse>();

            CreateMap<Course, GetListedCourseResponse>();
            CreateMap<Paginate<Course>, Paginate<GetListedCourseResponse>>();

            CreateMap<Course, GetCourseResponse>().ReverseMap();

            CreateMap<UpdateCourseRequest, Course>().ReverseMap();
            CreateMap<Course, UpdatedCourseResponse>().ReverseMap();

            CreateMap<DeleteCourseRequest, Course>().ReverseMap();
            CreateMap<Course, DeletedCourseResponse>().ReverseMap();

            CreateMap<Course, GetListedCourseResponse>()
                .ForMember(destinationMember: p => p.CategoryId,
                memberOptions: opt => opt.MapFrom(p => p.Category.Id)).ReverseMap();

            CreateMap<Course, GetListedCourseResponse>()
                .ForMember(destinationMember: p => p.CategoryName,
                memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();

            CreateMap<Course, GetListedCourseResponse>()
                .ForMember(destinationMember: p => p.InstructorId,
                memberOptions: opt => opt.MapFrom(p => p.Instructor.Id)).ReverseMap();

            CreateMap<Course, GetListedCourseResponse>()
                .ForMember(destinationMember: p => p.InstructorName,
                memberOptions: opt => opt.MapFrom(p => p.Instructor.Name)).ReverseMap();
        }
    }
}
