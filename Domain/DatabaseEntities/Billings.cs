using System;
using System.Collections.Generic;

namespace Hospital_Management_System.Domain.DatabaseEntities;

public partial class Billings
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public DateTime BillingDate { get; set; }

    public decimal Amount { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual Patients Patient { get; set; } = null!;
}
