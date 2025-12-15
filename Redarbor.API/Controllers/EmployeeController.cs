using Microsoft.AspNetCore.Mvc;
using Redarbor.Application.Commands.Employee;
using Redarbor.Application.Queries.Employee;

namespace Redarbor.API.Controllers;

public class EmployeeController : BaseApiController
{
    [HttpPost()]
    public async Task<IActionResult> Post(CreateEmployeeCommand command)
    => Ok(await Mediator.Send(command));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) =>
        Ok(await Mediator.Send(new DeleteEmployeeCommand() { Id = id }));

    [HttpGet()]
    public async Task<IActionResult> Get() =>
          Ok(await Mediator!.Send(new GetAllEmployeeQuery() { }));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id) =>
        Ok(await Mediator.Send(new GetEmployeeByIdQuery() { Id = id }));

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateEmployeeCommand command)
    {
        if (id != command.Id)
            return BadRequest();
        return Ok(await Mediator.Send(command));
    }
}
