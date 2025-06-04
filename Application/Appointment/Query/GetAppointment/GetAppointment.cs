namespace Hospital_Management_System.Application.Appointment.Query.GetAppointment
{
    public record GetAppointmentQuery : IRequest<GetAppointmentQueryDto>
    {
        public string Name { get; set; } = string.Empty;
        public string IdentificationNumber { get; set; } = string.Empty;
    }
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery,GetAppointmentQueryDto>
    {
        private readonly HospitalDbContext _DbContext;
        private readonly IMapper _Mapper;
        public GetAppointmentQueryHandler(HospitalDbContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
        }

        public async Task<GetAppointmentQueryDto> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
        {
            GetAppointmentQueryDto appointment = await _DbContext.Appointments
                .Where(a => a.Patient.Name == request.Name && a.Patient.IdentificationNumber == request.IdentificationNumber)
                .ProjectTo<GetAppointmentQueryDto>(_Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken) ?? throw new Exception($"No Apppointment found for {request.Name}");

            return appointment;
        }
    }
}
