using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CourseRequest;
using Business.Dtos.Responses.CourseResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal _courseDal;
        private readonly IMapper _mapper;
        public CourseManager(ICourseDal courseDal, IMapper mapper)
        {
            _courseDal = courseDal;
            _mapper = mapper;
        }

        public async Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest)
        {
            Course course = _mapper.Map<Course>(createCourseRequest);
            course.Id = Guid.NewGuid();
            Course createdCourse = await _courseDal.AddAsync(course);
            CreatedCourseResponse createdCategoryResponse = _mapper.Map<CreatedCourseResponse>(createdCourse);
            return createdCategoryResponse;
        }

        public async Task<IPaginate<GetListedCourseResponse>> GetListAsync()
        {
            var courseList = await _courseDal.GetListAsync();
            List<GetListedCourseResponse> getList = _mapper.Map<List<GetListedCourseResponse>>(courseList.Items);
            Paginate<GetListedCourseResponse> paginate = _mapper.Map<Paginate<GetListedCourseResponse>>(courseList);
            paginate.Items = getList;
            return paginate;
        }
    }
}
