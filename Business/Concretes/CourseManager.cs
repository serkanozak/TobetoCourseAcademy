using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos;
using Business.Dtos.Requests.CategoryRequest;
using Business.Dtos.Requests.CourseRequest;
using Business.Dtos.Requests.CourseRequests;
using Business.Dtos.Responses.CategoryResponses;
using Business.Dtos.Responses.CourseResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

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

        public async Task<CreatedCourseResponse> AddAsync(CreateCourseRequest createCourseRequest)
        {
            Course course = _mapper.Map<Course>(createCourseRequest);
            course.Id = Guid.NewGuid();
            Course createdCourse = await _courseDal.AddAsync(course);
            CreatedCourseResponse createdCourseResponse = _mapper.Map<CreatedCourseResponse>(createdCourse);
            return createdCourseResponse;
        }

        public async Task<IEnumerable<CreatedCourseResponse>> AddRangeAsync(IEnumerable<CreateCourseRequest> createCourseRequests)
        {
            List<Course> courses = createCourseRequests.Select(request => _mapper.Map<Course>(request)).ToList();

            foreach (var course in courses)
            {
                course.Id = Guid.NewGuid();
            }

            await _courseDal.AddRangeAsync(courses);

            IEnumerable<CreatedCourseResponse> createdCourseResponses = courses.Select(c => _mapper.Map<CreatedCourseResponse>(c));

            return createdCourseResponses;
        }

        public async Task<DeletedCourseResponse> DeleteAsync(DeleteCourseRequest deleteCourseRequest)
        {
            Course deleteCourse = await _courseDal.GetAsync(c => c.Id == deleteCourseRequest.Id);
            await _courseDal.DeleteAsync(deleteCourse);
            DeletedCourseResponse deletedCourseResponse = _mapper.Map<DeletedCourseResponse>(deleteCourse);
            return deletedCourseResponse;
        }

        public async Task<ICollection<DeletedCourseResponse>> DeleteRangeAsync(ICollection<DeleteCourseRequest> deleteCourseRequests)
        {
            List<Course> courses = deleteCourseRequests.Select(request => _mapper.Map<Course>(request)).ToList();

            // Silinecek ürünlerin Id gelecek.
            var courseIds = courses.Select(c => c.Id).ToList();

            // Ürünleri paginate olarak alıyoruz.
            var paginatedCourses = await _courseDal.GetListAsync(c => courseIds.Contains(c.Id));

            // Paginatetten sadece ürünleri çekiyoruz.
            var coursesToDelete = paginatedCourses.Items.ToList();

            // Range e göre siliyoruz.
            await _courseDal.DeleteRangeAsync(coursesToDelete);

            var deletedResponses = _mapper.Map<ICollection<DeletedCourseResponse>>(coursesToDelete);

            return deletedResponses;
        }

        public async Task<GetCourseResponse> GetById(GetCourseRequest getCourseRequest)
        {
            Course getCourse = await _courseDal.GetAsync(c => c.Id == getCourseRequest.Id);
            GetCourseResponse courseResponse = _mapper.Map<GetCourseResponse>(getCourse);
            return courseResponse;
        }

        public async Task<IPaginate<GetListedCourseResponse>> GetListAsync(PageRequest pageRequest)
        {
            var getList = await _courseDal.GetListAsync(include: c => c.Include(c => c.Category)
                .Include(c => c.Instructor),
                index: pageRequest.Index, size: pageRequest.Size);

            var result = _mapper.Map<Paginate<GetListedCourseResponse>>(getList);
            return result;
        }

        public async Task<UpdatedCourseResponse> UpdateAsync(UpdateCourseRequest updateCourseRequest)
        {
            Course updateCourse = await _courseDal.GetAsync(c => c.Id == updateCourseRequest.Id);
            _mapper.Map(updateCourseRequest, updateCourse);
            Course updatedCourse = await _courseDal.UpdateAsync(updateCourse);
            UpdatedCourseResponse updatedCourseResponse = _mapper.Map<UpdatedCourseResponse>(updatedCourse);
            return updatedCourseResponse;
        }

        public async Task<ICollection<UpdatedCourseResponse>> UpdateRangeAsync(ICollection<UpdateCourseRequest> updateCourseRequests)
        {
            ICollection<Course> entities = _mapper.Map<ICollection<Course>>(updateCourseRequests);

            await _courseDal.UpdateRangeAsync(entities);

            var updatedResponses = _mapper.Map<ICollection<UpdatedCourseResponse>>(entities);

            return updatedResponses;
        }
    }
}
