
using Hospital_Management_System.Domain.DatabaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Application.Appointment.Command
{
    public record AddAppointmentCommand : IRequest
    {
        public int patientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }

    }

    public class AddAppointmentCommandHandle : IRequestHandler<AddAppointmentCommand>
    {
        private readonly HospitalDbContext _dbContext;
        public AddAppointmentCommandHandle(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            Domain.DatabaseEntities.Appointment appointment = new()
            {
                DoctorId = request.DoctorId,
                PatientId = request.patientId,
                AppointmentDate = request.AppointmentDate,
                Status = "New"
            };

            await _dbContext.Appointments.AddAsync(appointment, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
