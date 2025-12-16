using Bogus;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Redarbor.Application.Commands.Employee;
using Redarbor.Application.Queries.Employee;
using Redarbor.Application.Queries.Employee.Models;
using Redarbor.Application.Shared.Wrappers;
using Redarbor.Domain.Entities;
using Redarbor.Domain.Shared.Enums;
using System.Text;
using System.Text.Json;

namespace Redarbor.Test.IntegrationTest.Application;

[TestFixture]
public class CreateEmployeeCommandTests
{
    private Mock<IMediator> _mediatorMock = new();
    private readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [SetUp]
    public void Setup()
    {
        _mediatorMock = new Mock<IMediator>();
    }

    [Test]
    public async Task Post_Returns_Guid_When_Mediator_Returns_Success()
    {
        var expectedId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateEmployeeCommand>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new Response<Guid>(expectedId));

        await using var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<IMediator>(_mediatorMock.Object);
                });
            });

        using var client = factory.CreateClient();

        var faker = new Faker<CreateEmployeeCommand>()
            .RuleFor(x => x.Name, f => f.Person.FullName)
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Telephone, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.Fax, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.PortalId, f => Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"))
            .RuleFor(x => x.CompanyId, f => Guid.Parse("a2220b31-1402-485c-bcef-904b6dec977e"))
            .RuleFor(x => x.RoleId, f => Guid.Parse("b0c4a2e9-61d0-459d-a35b-82d0e4a7f85e"))
            .RuleFor(x => x.Status, f => Status.Active)
            .RuleFor(x => x.Username, f => f.Internet.UserName())
            .RuleFor(x => x.Password, f => f.Internet.Password());

        var command = faker.Generate();

        var json = JsonSerializer.Serialize(command);
        using var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/redarbor/employee", content);

        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        var wrapper = JsonSerializer.Deserialize<Response<Guid>>(body, JsonOptions);
        Assert.That(wrapper, Is.Not.Null);
        Assert.That(wrapper!.IsSucess, Is.True);
        Assert.That(wrapper.Result, Is.EqualTo(expectedId));
    }

    [Test]
    public async Task Get_Returns_ListOfEmployees_When_Mediator_Returns_Success()
    {
        var employeeFaker = new Faker<Employee>()
            .CustomInstantiator(f => Employee.Create(
                f.Name.FullName(),
                f.Internet.Email(),
                f.Phone.PhoneNumber(),
                f.Phone.PhoneNumber(),
                Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Guid.Parse("a2220b31-1402-485c-bcef-904b6dec977e"),
                Guid.Parse("b0c4a2e9-61d0-459d-a35b-82d0e4a7f85e"),
                Status.Active));

        var fakeEmployees = employeeFaker.Generate(3);
        var responseModel = new GetEmployeeResponseModel { Employees = fakeEmployees };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllEmployeeQuery>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new Response<GetEmployeeResponseModel>(responseModel));

        await using var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<IMediator>(_mediatorMock.Object);
                });
            });

        using var client = factory.CreateClient();

        var response = await client.GetAsync("/api/redarbor/employee");
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        var wrapper = JsonSerializer.Deserialize<Response<GetEmployeeResponseModel>>(body, JsonOptions);
        Assert.That(wrapper, Is.Not.Null);
        Assert.That(wrapper!.IsSucess, Is.True);
        Assert.That(wrapper.Result, Is.Not.Null);
        Assert.That(wrapper.Result!.Employees, Is.Not.Empty);
    }

    [Test]
    public async Task Put_Returns_BadRequest_When_Id_Mismatch()
    {
        await using var factory = new WebApplicationFactory<Program>();
        using var client = factory.CreateClient();

        var faker = new Faker<UpdateEmployeeCommand>()
            .RuleFor(x => x.Id, Guid.NewGuid())
            .RuleFor(x => x.Name, f => f.Person.FullName)
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Telephone, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.Fax, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.PortalId, f => Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"))
            .RuleFor(x => x.CompanyId, f => Guid.Parse("a2220b31-1402-485c-bcef-904b6dec977e"))
            .RuleFor(x => x.RoleId, f => Guid.Parse("b0c4a2e9-61d0-459d-a35b-82d0e4a7f85e"))
            .RuleFor(x => x.UserId, f => Guid.NewGuid())
            .RuleFor(x => x.Status, f => Status.Active);

        var command = faker.Generate();
        var differentId = Guid.NewGuid(); // mismatch
        var json = JsonSerializer.Serialize(command);
        using var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PutAsync($"/api/redarbor/employee/{differentId}", content);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));
    }
}
