using AutoMapper;
using Hospital_Management_System.Domain.DatabaseEntities;

namespace Hospital_Management_System.Application.Doctor.Query
{
    public class GetDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
    }

    public class GetDoctorDtoProfile : Profile
    {
        public GetDoctorDtoProfile()
        {
            CreateMap<Doctors, GetDoctorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialty))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.ContactNumber));
        }
    }
}