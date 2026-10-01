using Microsoft.AspNetCore.Mvc;
using TacheApp.Domain.Common;
using TacheApp.Domain.Common.Errors;

namespace TacheApp.Api.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected ActionResult HandleFailure(Result result)
        {
            if (result.IsSuccess)
            {
                throw new InvalidOperationException("Ne peut pas gérer un échec sur un résultat positif.");
            }

            return result.Error.Type switch
            {
                ErrorType.NotFound => NotFound(new { result.Error.Code, result.Error.Description }),
                ErrorType.Validation => BadRequest(new { result.Error.Code, result.Error.Description }),
                ErrorType.Conflict => Conflict(new { result.Error.Code, result.Error.Description }),
                _ => StatusCode(500, new { result.Error.Code, result.Error.Description })
            };
        }
    }
}
