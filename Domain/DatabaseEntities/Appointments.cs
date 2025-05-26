using System;
using System.Collections.Generic;

namespace Hospital_Management_System.Domain.DatabaseEntities;

public partial class Appointments
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string? Status { get; set; }

    public virtual Doctors Doctor { get; set; } = null!;

    public virtual Patients Patient { get; set; } = null!;
}
