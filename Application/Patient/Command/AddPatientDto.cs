namespace Hospital_Management_System.Application.Patient.Command
{
    public class AddPatientDto
    {
        public string Name { get; set; } = string.Empty;
        public DateOnly DOB { get; set; }
        public string ContactNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    }
}
