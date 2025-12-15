using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Redarbor.API.Controllers;

[ApiController]
[Route("api/redarbor/[controller]")]
public class BaseApiController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
}
