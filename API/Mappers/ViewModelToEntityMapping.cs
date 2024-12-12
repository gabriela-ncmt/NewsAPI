using API.Entities;
using API.Entities.ViewsModels;
using AutoMapper;

namespace API.Mappers
{
    public class ViewModelToEntityMapping : Profile
    {
        public ViewModelToEntityMapping()
        {
            CreateMap<NewsViewModel, News> ();
        }
    }
}
