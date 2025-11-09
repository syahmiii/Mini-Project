namespace Hospital_Management_System.Application.Doctor.Command
{
    public class AddDoctorCommand
    {
        public string Name { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
    }

    public class AddDoctorCommandHandle : IRequest<AddDoctorCommand>
    {
        private readonly HospitalDbContext _dbContext;

        public AddDoctorCommandHandle(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(AddDoctorCommand request, CancellationToken cancellation)
        {
            Domain.DatabaseEntities.Doctor doctor = new()
            {
                FullName = request.Name,
                ContactNumber = request.ContactNumber,
                Specialty = request.Speciality
            };

            await _dbContext.Doctors.AddAsync(doctor);

            await _dbContext.SaveChangesAsync(cancellation);
        }

    }
}
