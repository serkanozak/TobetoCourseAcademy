using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Requests.CategoryRequest;
using Business.Dtos.Requests.CategoryRequests;
using Business.Dtos;
using Business.Dtos.Requests.InstructorRequest;
using Business.Dtos.Responses.CategoryResponses;
using Business.Dtos.Responses.InstructorResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Business.Dtos.Requests.InstructorRequests;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<IPaginate<GetListedInstructorResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetInstructorResponse> GetById(GetInstructorRequest getInstructorRequest);
        Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest createInstructorRequest);
        Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest updateInstructorRequest);
        Task<DeletedInstructorResponse> DeleteAsync(DeleteInstructorRequest deleteInstructorRequest);
        Task<IEnumerable<CreatedInstructorResponse>> AddRangeAsync(IEnumerable<CreateInstructorRequest> createInstructorRequests);
        Task<ICollection<UpdatedInstructorResponse>> UpdateRangeAsync(ICollection<UpdateInstructorRequest> updateInstructorRequests);
        Task<ICollection<DeletedInstructorResponse>> DeleteRangeAsync(ICollection<DeleteInstructorRequest> deleteInstructorRequests);
    }
}
