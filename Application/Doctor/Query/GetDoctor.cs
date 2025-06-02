namespace Hospital_Management_System.Application.Doctor.Query;

using System.Threading;
using System.Threading.Tasks;

public record GetDoctorQuery : IRequest<GetDoctorDto>
{
    public int DoctorId { get; init; }
}

public class GetDoctorQueryHandler: IRequestHandler<GetDoctorQuery, GetDoctorDto>
{
    private readonly HospitalDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDoctorQueryHandler(
        HospitalDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetDoctorDto> Handle(GetDoctorQuery request, CancellationToken cancellationToken)
    {
        GetDoctorDto doctor = await _dbContext.Doctors
            .AsNoTracking()
            .Where(x => x.Id == request.DoctorId)
            .ProjectTo<GetDoctorDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);

        return doctor;


    }
}