using AutoMapper;
using Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Helpers
{
    public class MapingProfiles : Profile
    {
        public MapingProfiles() 
        {
            CreateMap<Department, DepartmentViewModel>()
          .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
          .ForMember(d => d.Manager, o => o.MapFrom(s => s.Manager));
        }
    }
}
