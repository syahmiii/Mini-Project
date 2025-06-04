namespace Hospital_Management_System.Application.Patient.Query.GetPatient
{
    public class GetPatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
    }

    public class GetPatientDtoProfile : Profile
    {
        public GetPatientDtoProfile()
        {
            CreateMap<Domain.DatabaseEntities.Patient, GetPatientDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.Dob ?? DateOnly.MinValue))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }
    }
}
