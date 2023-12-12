using Business.Abstracts;
using Business.Dtos;
using Business.Dtos.Requests.CourseRequest;
using Business.Dtos.Requests.CourseRequests;
using Business.Dtos.Requests.InstructorRequest;
using Business.Dtos.Requests.InstructorRequests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _courseService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCourseRequest createCourseRequest)
        {
            var result = await _courseService.AddAsync(createCourseRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseRequest updateCourseRequest)
        {
            var result = await _courseService.UpdateAsync(updateCourseRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCourseRequest deleteCourseRequest)
        {
            var result = await _courseService.DeleteAsync(deleteCourseRequest);
            return Ok(result);
        }

        [HttpPost("AddRange")]
        public async Task<IActionResult> AddRangeAsync([FromBody] List<CreateCourseRequest> createCourseRequest)
        {
            var result = await _courseService.AddRangeAsync(createCourseRequest);
            return Ok(result);
        }

        [HttpPost("UpdateRange")]
        public async Task<IActionResult> UpdateRangeAsync([FromBody] List<UpdateCourseRequest> updateCourseRequests)
        {
            var result = await _courseService.UpdateRangeAsync(updateCourseRequests);
            return Ok(result);
        }

        [HttpPost("DeleteRange")]
        public async Task<IActionResult> DeleteRangeAsync([FromBody] List<DeleteCourseRequest> deleteCourseRequests)
        {
            var result = await _courseService.DeleteRangeAsync(deleteCourseRequests);
            return Ok(result);
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetCourseRequest getCourseRequest)
        {
            var result = await _courseService.GetById(getCourseRequest);
            return Ok(result);
        }
    }
}
