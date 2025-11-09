using Hospital_Management_System.Application.Doctor.Command;
using Hospital_Management_System.Application.Doctor.Query;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet(nameof(GetDoctor))]
    public Task<GetDoctorDto> GetDoctor([FromQuery] GetDoctorQuery request)
    {
        Task<GetDoctorDto> result = _mediator.Send(request);
        return result; 
    }

    [HttpPost(nameof(AddDoctor))]
    public async Task<IActionResult> AddDoctor([FromBody] AddDoctorCommand request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}