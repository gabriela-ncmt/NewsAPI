using NewsAPI.Entities;
using NewsAPI.Entities.ViewsModels;
using AutoMapper;

namespace NewsAPI.Mappers
{
    public class EntityToViewModelMapping : Profile
    {
        public EntityToViewModelMapping()
        {
            CreateMap<News, NewsViewModel>();
        }
    }
}
