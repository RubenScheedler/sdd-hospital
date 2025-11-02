using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SDD.Hospital.Api.IntegrationTests
{
    public class RegisterPatientTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public RegisterPatientTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task PostValidPatient_ReturnsCreated()
        {
            var client = _factory.CreateClient();
            var req = new
            {
                firstName = "Alice",
                lastName = "Smith",
                dateOfBirth = "1995-05-01",
                email = "alice@example.com",
                phoneNumber = "+1234567890"
            };

            var res = await client.PostAsJsonAsync("/api/patients", req);
            Assert.Equal(System.Net.HttpStatusCode.Created, res.StatusCode);
        }
    }
}
