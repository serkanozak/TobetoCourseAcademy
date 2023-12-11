using AutoMapper;
using Business.Dtos.Requests.CategoryRequest;
using Business.Dtos.Responses.CategoryResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<Category, CreatedCategoryResponse>();

            CreateMap<Category, GetListedCategoryResponse>();
            CreateMap<Paginate<Category>, Paginate<GetListedCategoryResponse>>();
        }
    }
}
