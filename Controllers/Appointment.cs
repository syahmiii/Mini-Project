using Hospital_Management_System.Application.Appointment.Command;
using Hospital_Management_System.Application.Appointment.Query.GetAppointment;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpGet(nameof(GetAppointment))]
        public Task<GetAppointmentQueryDto> GetAppointment([FromQuery] GetAppointmentQuery request)
        {
            Task<GetAppointmentQueryDto> result = _mediator.Send(request);

            return result;
        }

        [HttpPost(nameof(AddAppointment))]
        public async Task<IActionResult> AddAppointment([FromBody]AddAppointmentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        
        }

    }
}
