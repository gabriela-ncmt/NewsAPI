using NewsAPI.Entities;
using NewsAPI.Entities.ViewsModels;
using AutoMapper;

namespace NewsAPI.Mappers
{
    public class ViewModelToEntityMapping : Profile
    {
        public ViewModelToEntityMapping()
        {
            CreateMap<NewsViewModel, News> ();
        }
    }
}
