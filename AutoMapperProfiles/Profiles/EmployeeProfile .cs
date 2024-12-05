using AutoMapper;
using AutoMapperModels.Models;

namespace AutoMapperProfiles.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // Định nghĩa cách ánh xạ từ Employee sang EmployeeDTO
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));
        }
    }
}
