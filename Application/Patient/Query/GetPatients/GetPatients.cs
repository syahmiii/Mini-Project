namespace Hospital_Management_System.Application.Patient.Query.GetPatients
{
    public record GetPatientsQuery : IRequest<List<GetPatientsDto>>
    {
        public List<int> PatientId { get; init; } = new();
    }

    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, List<GetPatientsDto>>
    {
        private readonly HospitalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPatientsQueryHandler(HospitalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GetPatientsDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            List<GetPatientsDto> patients = await _dbContext.Patients
                .AsNoTracking()
                .Where(p => request.PatientId.Contains(p.Id))
                .ProjectTo<GetPatientsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return patients;
        }
    }
}
