using System;
using System.Collections.Generic;

namespace Hospital_Management_System.Domain.DatabaseEntities;

public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? Dob { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string IdentificationNumber { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();
}
