using Business.Abstracts;
using Business.Dtos.Requests.CategoryRequest;
using Business.Dtos.Requests.CategoryRequests;
using Business.Dtos;
using Business.Dtos.Requests.InstructorRequest;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.InstructorRequests;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        IInstructorService _instructorService;
        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _instructorService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateInstructorRequest createInstructorRequest)
        {
            var result = await _instructorService.AddAsync(createInstructorRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateInstructorRequest updateInstructorRequest)
        {
            var result = await _instructorService.UpdateAsync(updateInstructorRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteInstructorRequest deleteInstructorRequest)
        {
            var result = await _instructorService.DeleteAsync(deleteInstructorRequest);
            return Ok(result);
        }

        [HttpPost("AddRange")]
        public async Task<IActionResult> AddRangeAsync([FromBody] List<CreateInstructorRequest> createInstructorRequest)
        {
            var result = await _instructorService.AddRangeAsync(createInstructorRequest);
            return Ok(result);
        }

        [HttpPost("UpdateRange")]
        public async Task<IActionResult> UpdateRangeAsync([FromBody] List<UpdateInstructorRequest> updateInstructorRequests)
        {
            var result = await _instructorService.UpdateRangeAsync(updateInstructorRequests);
            return Ok(result);
        }

        [HttpPost("DeleteRange")]
        public async Task<IActionResult> DeleteRangeAsync([FromBody] List<DeleteInstructorRequest> deleteInstructorRequests)
        {
            var result = await _instructorService.DeleteRangeAsync(deleteInstructorRequests);
            return Ok(result);
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetInstructorRequest getInstructorRequest)
        {
            var result = await _instructorService.GetById(getInstructorRequest);
            return Ok(result);
        }
    }


}
