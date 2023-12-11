using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.InstructorRequest;
using Business.Dtos.Responses.InstructorResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Query;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorDal _instructorDal;
        private readonly IMapper _mapper;
        public InstructorManager(IInstructorDal instructorDal, IMapper mapper)
        {
            _instructorDal = instructorDal;
            _mapper = mapper;
        }

        public async Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest)
        {
            Instructor instructor = _mapper.Map<Instructor>(createInstructorRequest);
            instructor.Id = Guid.NewGuid();

            Instructor createdInstructor = await _instructorDal.AddAsync(instructor);

            CreatedInstructorResponse createdInstructorResponse = _mapper.Map<CreatedInstructorResponse>(createdInstructor);
            return createdInstructorResponse;
        }

        public async Task<IPaginate<GetListedInstructorResponse>> GetListAsync()
        {
            var instructorList = await _instructorDal.GetListAsync();
            List<GetListedInstructorResponse> getList = _mapper.Map<List<GetListedInstructorResponse>>(instructorList.Items);
            Paginate<GetListedInstructorResponse> paginate = _mapper.Map<Paginate<GetListedInstructorResponse>>(instructorList);
            paginate.Items = getList;
            return paginate;
        }
    }
}
