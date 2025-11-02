using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SDD.Hospital.Application.Commands;
using SDD.Hospital.Application.UseCases;
using SDD.Hospital.Api.Models;

namespace SDD.Hospital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly RegisterPatientUseCase _useCase;

        public PatientsController(RegisterPatientUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterPatientRequest req)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cmd = new RegisterPatientCommand(req.FirstName, req.LastName, req.DateOfBirth, req.Email, req.PhoneNumber);
            var id = await _useCase.Handle(cmd);
            return CreatedAtAction(nameof(Get), new { id }, value: null);
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id) => Ok(new { id });
    }

    // DTOs moved to src/SDD.Hospital.Api/Models/RegisterPatientRequest.cs
}
