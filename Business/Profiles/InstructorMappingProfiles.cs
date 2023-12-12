using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Requests.CategoryRequest;
using Business.Dtos.Requests.CategoryRequests;
using Business.Dtos.Requests.InstructorRequest;
using Business.Dtos.Requests.InstructorRequests;
using Business.Dtos.Responses.CategoryResponses;
using Business.Dtos.Responses.InstructorResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Mapping
{

    public class InstructorMappingProfiles : Profile
    {
        public InstructorMappingProfiles()
        {
            CreateMap<CreateInstructorRequest, Instructor>();
            CreateMap<Instructor, CreatedInstructorResponse>();

            CreateMap<Instructor, GetListedInstructorResponse>();
            CreateMap<Paginate<Instructor>, Paginate<GetListedInstructorResponse>>();

            CreateMap<Instructor, GetInstructorResponse>().ReverseMap();

            CreateMap<DeleteInstructorRequest, Instructor>().ReverseMap();
            CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();

            CreateMap<UpdateInstructorRequest, Instructor>().ReverseMap();
            CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();

        }
    }
}
