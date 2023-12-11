using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Requests.InstructorRequest;
using Business.Dtos.Responses.InstructorResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Mapping
{

    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<CreateInstructorRequest, Instructor>();
            CreateMap<Instructor, CreatedInstructorResponse>();

            CreateMap<Instructor, GetListedInstructorResponse>();
            CreateMap<Paginate<Instructor>, Paginate<GetListedInstructorResponse>>();
        }
    }
}
