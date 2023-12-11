using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Requests.CourseRequest;
using Business.Dtos.Responses.CourseResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface ICourseService
    {
        Task<IPaginate<GetListedCourseResponse>> GetListAsync();
        Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest);

    }
}
