namespace Hospital_Management_System.Application.Patient.Command
{
    public record AddPatientCommand
    {
        public string FirstName { get; init; } = string.Empty;
        public DateOnly DOB { get; init; }
        public string ContactNumber { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;
    }

    public class AddPatientCommandhandler : IRequest<AddPatientCommand>
    {
        private readonly HospitalDbContext _context;

        public AddPatientCommandhandler(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {

            Patients patient = new ()
            {
                Name = request.FirstName,
                Dob = request.DOB,
                ContactNumber = request.ContactNumber,
                Address = request.Address
            };


            await _context.Patients.AddAsync(patient, cancellationToken: cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

        }

    }
}
