using FluentResults;
using HicomInterview.Validation;
using Microsoft.AspNetCore.Mvc;

namespace HicomInterview.Web.Controllers
{
    public class BaseController : Controller
    {
        public void SetModelState<TResult>(Result<TResult> result)
        {
            result.HasError(out IEnumerable<ValidationError> validationErrors);

            validationErrors.ToList().ForEach(error => ModelState.AddModelError(error?.PropertyName!, error?.Message!));
        }
    }
}
