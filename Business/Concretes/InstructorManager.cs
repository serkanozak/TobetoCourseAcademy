using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos;
using Business.Dtos.Requests.CategoryRequest;
using Business.Dtos.Requests.CategoryRequests;
using Business.Dtos.Requests.InstructorRequest;
using Business.Dtos.Requests.InstructorRequests;
using Business.Dtos.Responses.CategoryResponses;
using Business.Dtos.Responses.InstructorResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
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

        public async Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest createInstructorRequest)
        {
            Instructor instructor = _mapper.Map<Instructor>(createInstructorRequest);
            instructor.Id = Guid.NewGuid();

            Instructor createdInstructor = await _instructorDal.AddAsync(instructor);

            CreatedInstructorResponse createdInstructorResponse = _mapper.Map<CreatedInstructorResponse>(createdInstructor);
            return createdInstructorResponse;
        }

        public async Task<IEnumerable<CreatedInstructorResponse>> AddRangeAsync(IEnumerable<CreateInstructorRequest> createInstructorRequests)
        {
            List<Instructor> instructors = createInstructorRequests.Select(request => _mapper.Map<Instructor>(request)).ToList();

            foreach (var instructor in instructors)
            {
                instructor.Id = Guid.NewGuid();
            }

            await _instructorDal.AddRangeAsync(instructors);

            IEnumerable<CreatedInstructorResponse> createdInstructorResponses = instructors.Select(p => _mapper.Map<CreatedInstructorResponse>(p));

            return createdInstructorResponses;
        }

        public async Task<DeletedInstructorResponse> DeleteAsync(DeleteInstructorRequest deleteInstructorRequest)
        {
            Instructor deleteInstructor = await _instructorDal.GetAsync(i => i.Id == deleteInstructorRequest.Id);
            await _instructorDal.DeleteAsync(deleteInstructor);
            return _mapper.Map<DeletedInstructorResponse>(deleteInstructor);
        }

        public async Task<ICollection<DeletedInstructorResponse>> DeleteRangeAsync(ICollection<DeleteInstructorRequest> deleteInstructorRequests)
        {
            List<Instructor> instructors = deleteInstructorRequests.Select(request => _mapper.Map<Instructor>(request)).ToList();

            // Silinecek ürünlerin Id gelecek.
            var instructorIds = instructors.Select(i => i.Id).ToList();

            // Ürünleri paginate olarak alıyoruz.
            var paginatedInstructors = await _instructorDal.GetListAsync(i => instructorIds.Contains(i.Id));

            // Paginatetten sadece ürünleri çekiyoruz.
            var instructorsToDelete = paginatedInstructors.Items.ToList();

            // Range e göre siliyoruz.
            await _instructorDal.DeleteRangeAsync(instructorsToDelete);

            var deletedResponses = _mapper.Map<ICollection<DeletedInstructorResponse>>(instructorsToDelete);

            return deletedResponses;
        }

        public async Task<GetInstructorResponse> GetById(GetInstructorRequest getInstructorRequest)
        {
            Instructor getInstructor = await _instructorDal.GetAsync(i => i.Id == getInstructorRequest.Id);
            GetInstructorResponse instructorResponse = _mapper.Map<GetInstructorResponse>(getInstructor);
            return instructorResponse;
        }

        public async Task<IPaginate<GetListedInstructorResponse>> GetListAsync(PageRequest pageRequest)
        {
            var getList = await _instructorDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
            var result = _mapper.Map<Paginate<GetListedInstructorResponse>>(getList);
            return result;
        }

        public async Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest updateInstructorRequest)
        {
            Instructor updateInstructor = await _instructorDal.GetAsync(i => i.Id == updateInstructorRequest.Id);
            _mapper.Map(updateInstructorRequest, updateInstructor);
            Instructor updatedInstructor = await _instructorDal.UpdateAsync(updateInstructor);
            return _mapper.Map<UpdatedInstructorResponse>(updatedInstructor);
        }

        public async Task<ICollection<UpdatedInstructorResponse>> UpdateRangeAsync(ICollection<UpdateInstructorRequest> updateInstructorRequests)
        {
            ICollection<Instructor> entities = _mapper.Map<ICollection<Instructor>>(updateInstructorRequests);

            await _instructorDal.UpdateRangeAsync(entities);

            var updatedResponses = _mapper.Map<ICollection<UpdatedInstructorResponse>>(entities);

            return updatedResponses;
        }
    }
}
