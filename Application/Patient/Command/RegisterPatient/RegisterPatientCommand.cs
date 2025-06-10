namespace Hospital_Management_System.Application.Patient.Command.RegisterPatient
{
    public record RegisterPatientCommand
    {
        public string Name { get; set; } = string.Empty;

        public DateOnly Dob { get; set; }

        public string ContactNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

    }
    public class RegisterPatientCommandHandler
    {
        private readonly HospitalDbContext _DbContext;
        public RegisterPatientCommandHandler(HospitalDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
        {

            var existingPatient = await _DbContext.Patients
                .FirstOrDefaultAsync(p => p.Name == request.Name && p.ContactNumber == request.ContactNumber, cancellationToken);

            // since use ef core, adding like this should be fine 
            if (existingPatient == null)
            {

                var appointment = new Domain.DatabaseEntities.Appointment
                {
                    DoctorId = request.DoctorId,
                    AppointmentDate = request.AppointmentDate,
                    Patient = new Domain.DatabaseEntities.Patient
                    {
                        Name = request.Name,
                        Dob = request.Dob,
                        ContactNumber = request.ContactNumber,
                        Address = request.Address
                    }
                };

                await _DbContext.Appointments.AddAsync(appointment, cancellationToken: cancellationToken);
                await _DbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                Domain.DatabaseEntities.Appointment appointment = new()
                {
                    PatientId = existingPatient.Id,
                    DoctorId = request.DoctorId,
                    AppointmentDate = request.AppointmentDate
                };

                await _DbContext.Appointments.AddAsync(appointment, cancellationToken: cancellationToken);
                await _DbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
