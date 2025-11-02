using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SDD.Hospital.Application.Commands;
using SDD.Hospital.Application.UseCases;

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
            var cmd = new RegisterPatientCommand(req.FirstName, req.LastName, req.DateOfBirth);
            var id = await _useCase.Handle(cmd);
            return CreatedAtAction(nameof(Get), new { id }, new { id });
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id) => Ok(new { id });
    }

    public record RegisterPatientRequest(string FirstName, string LastName, DateTime DateOfBirth);
}
