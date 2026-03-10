

using Application.Business.DoctorSchedules.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace MedFlow.Api.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorScheduleController : MedFlowApiController
    {
        private readonly IMediator _mediator;

        public DoctorScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{doctorId}/schedules")]
        public async Task<IActionResult> CreateById([FromRoute] Guid doctorId, [FromBody] CreateDoctorSchedulesReqeust request)
        {
            request.DoctorId = doctorId;

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{doctorId}/schedules")]
        public async Task<IActionResult> GetByDoctorId([FromRoute] Guid doctorId)
        {
            var request = new GetDoctorSchedulesByDoctorIdRequest { DoctorId = doctorId };

            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
