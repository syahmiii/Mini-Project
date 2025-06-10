namespace Hospital_Management_System.Application.Patient.Query.GetPatients
{
    public class GetPatientsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
    }

    public class GetPatientsDtoProfile : Profile
    {
        public GetPatientsDtoProfile()
        {
            CreateMap<Domain.DatabaseEntities.Patient, GetPatientsDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.Dob ?? DateOnly.MinValue))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }
    }
}
