using AutoMapper;
using AutoMapperModels.Models;

namespace AutoMapperProfiles.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => GetFirstAndLastName(src.FullName)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => GetFirstAndLastName(src.FullName)));

        }

        private static (string FirstName, string LastName) GetFirstAndLastName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                return (string.Empty, string.Empty);

            var parts = fullName.Split(' ');

            string firstName = parts.Length > 0 ? parts[0] : string.Empty;
            string lastName = parts.Length > 1 ? string.Join(" ", parts.Skip(1)) : string.Empty;

            return (firstName, lastName);
        }

    }
}
