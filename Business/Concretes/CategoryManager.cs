using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CategoryRequest;
using Business.Dtos.Responses.CategoryResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
        {
            Category category = _mapper.Map<Category>(createCategoryRequest);
            category.Id = Guid.NewGuid();
            Category createdCategory = await _categoryDal.AddAsync(category);
            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(createdCategory);
            return createdCategoryResponse;
        }

        public async Task<IPaginate<GetListedCategoryResponse>> GetListAsync()
        {
            var categoryList = await _categoryDal.GetListAsync();
            List<GetListedCategoryResponse> getList = _mapper.Map<List<GetListedCategoryResponse>>(categoryList.Items);
            Paginate<GetListedCategoryResponse> paginate = _mapper.Map<Paginate<GetListedCategoryResponse>>(categoryList);
            paginate.Items = getList;
            return paginate;
        }
    }
}
