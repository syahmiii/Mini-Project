using System;
using System.Collections.Generic;

namespace Hospital_Management_System.Domain.DatabaseEntities;

public partial class Patients
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? Dob { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Appointments> Appointments { get; set; } = new List<Appointments>();

    public virtual ICollection<Billings> Billings { get; set; } = new List<Billings>();
}
