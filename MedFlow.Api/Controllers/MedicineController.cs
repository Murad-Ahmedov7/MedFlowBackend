using Application.Business.Medicines.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedFlow.Api.Controllers
{
    [Route("api/medicine")]
    [ApiController]
    public class MedicineController : MedFlowApiController
    {
        private readonly IMediator _mediator;

        public MedicineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMedicineRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin,Doctor")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var request = new GetMedicineByIdRequest { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin,Doctor")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllMedicinesRequest();

            var response = await _mediator.Send(request);

            return Ok(response);
        }


    }
}



