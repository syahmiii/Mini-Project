using AutoMapper;
using Hospital_Management_System.Domain.DatabaseEntities;
using MediatR;

namespace Hospital_Management_System.Application.Patient.Query.GetPatient
{
    public record GetPatientQuery : IRequest<GetPatientDto>
    {
        public int PatientId { get; init; }
    }


    public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, GetPatientDto>
    {
        private readonly HospitalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPatientQueryHandler(
            HospitalDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetPatientDto> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            GetPatientDto patient = await _dbContext.Patients
                .AsNoTracking()
                .Where(x => x.Id == request.PatientId)
                .ProjectTo<GetPatientDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Patient not found");

            return patient;
        }
    }
}
