using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Requests.CategoryRequest;
using Business.Dtos.Responses.CategoryResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        Task<IPaginate<GetListedCategoryResponse>> GetListAsync();
        Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest);
    }
}
