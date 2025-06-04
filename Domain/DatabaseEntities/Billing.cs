using System;
using System.Collections.Generic;

namespace Hospital_Management_System.Domain.DatabaseEntities;

public partial class Billing
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public DateTime BillingDate { get; set; }

    public decimal Amount { get; set; }
    public decimal PaidAmount { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
