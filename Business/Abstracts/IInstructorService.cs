using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Requests.InstructorRequest;
using Business.Dtos.Responses.InstructorResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<IPaginate<GetListedInstructorResponse>> GetListAsync();
        Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest);
    }
}
