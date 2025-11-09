using Hospital_Management_System.Application.Doctor.Command;
using Hospital_Management_System.Application.Doctor.Query;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers;

public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(nameof(GetPatient))]
    public Task<GetDoctorDto> GetPatient([FromQuery] GetDoctorQuery request)
    {
        Task<GetDoctorDto> result = _mediator.Send(request);
        return result;
    }

    [HttpPost(nameof(AddDoctor))]
    public async Task<IActionResult> AddDoctor([FromBody] AddDoctorCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}