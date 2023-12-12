using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;
using Business.Dtos.Requests.CourseRequest;
using Business.Dtos.Requests.CourseRequests;
using Business.Dtos.Requests.InstructorRequest;
using Business.Dtos.Requests.InstructorRequests;
using Business.Dtos.Responses.CourseResponses;
using Business.Dtos.Responses.InstructorResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface ICourseService
    {
        Task<IPaginate<GetListedCourseResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetCourseResponse> GetById(GetCourseRequest getCourseRequest);
        Task<CreatedCourseResponse> AddAsync(CreateCourseRequest createCourseRequest);
        Task<UpdatedCourseResponse> UpdateAsync(UpdateCourseRequest updateCourseRequest);
        Task<DeletedCourseResponse> DeleteAsync(DeleteCourseRequest deleteCourseRequest);
        Task<IEnumerable<CreatedCourseResponse>> AddRangeAsync(IEnumerable<CreateCourseRequest> createCourseRequests);
        Task<ICollection<UpdatedCourseResponse>> UpdateRangeAsync(ICollection<UpdateCourseRequest> updateCourseRequests);
        Task<ICollection<DeletedCourseResponse>> DeleteRangeAsync(ICollection<DeleteCourseRequest> deleteCourseRequests);

    }
}
