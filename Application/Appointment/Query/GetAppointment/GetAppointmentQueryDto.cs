namespace Hospital_Management_System.Application.Appointment.Query.GetAppointment
{
    public class GetAppointmentQueryDto
    {
        public int Id { get; set; }

        public int PatientName { get; set; }

        public string DoctorName { get; set; } = string.Empty;

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; } = string.Empty;

    }

    public class GetAppointmentQueryDtoProfile : Profile
    {
        public GetAppointmentQueryDtoProfile()
        {
            CreateMap<Domain.DatabaseEntities.Appointment, GetAppointmentQueryDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.Name))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName))
                .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => src.AppointmentDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status ?? string.Empty));
        }
    }
}