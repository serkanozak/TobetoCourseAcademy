using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;
using Business.Dtos.Requests.CategoryRequest;
using Business.Dtos.Requests.CategoryRequests;
using Business.Dtos.Responses.CategoryResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        Task<GetCategoryResponse> GetById(GetCategoryRequest getCategoryRequest);
        Task<IPaginate<GetListedCategoryResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCategoryResponse> AddAsync(CreateCategoryRequest createCategoryRequest);
        Task<UpdatedCategoryResponse> UpdateAsync(UpdateCategoryRequest updateCategoryRequest);
        Task<DeletedCategoryResponse> DeleteAsync(DeleteCategoryRequest deleteCategoryRequest);
        Task<IEnumerable<CreatedCategoryResponse>> AddRangeAsync(IEnumerable<CreateCategoryRequest> createCategoryRequests);
        Task<ICollection<UpdatedCategoryResponse>> UpdateRangeAsync(ICollection<UpdateCategoryRequest> updateCategoryRequests);
        Task<ICollection<DeletedCategoryResponse>> DeleteRangeAsync(ICollection<DeleteCategoryRequest> deleteCategoryRequests);
    }
}
