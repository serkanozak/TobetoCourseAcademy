using AutoMapper;
using Business.Dtos.Requests.CategoryRequest;
using Business.Dtos.Requests.CategoryRequests;
using Business.Dtos.Responses.CategoryResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Mapping
{
    public class CategoryMappingProfiles : Profile
    {
        public CategoryMappingProfiles()
        {
            CreateMap<CreateCategoryRequest, Category>().ReverseMap();
            CreateMap<Category, CreatedCategoryResponse>().ReverseMap();

            CreateMap<Category, GetCategoryResponse>().ReverseMap();

            CreateMap<DeleteCategoryRequest, Category>().ReverseMap();
            CreateMap<Category, DeletedCategoryResponse>().ReverseMap();

            CreateMap<UpdateCategoryRequest, Category>().ReverseMap();
            CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();

            CreateMap<GetListedCategoryResponse, Category>().ReverseMap();
            CreateMap<Paginate<GetListedCategoryResponse>, Paginate<Category>>().ReverseMap();
        }
    }
}
