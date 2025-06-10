using System;
using System.Collections.Generic;

namespace Hospital_Management_System.Domain.DatabaseEntities;

public partial class Doctor
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Specialty { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
