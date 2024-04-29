using FluentResults;
using FluentValidation.Results;

namespace HicomInterview.Validation
{
    public enum AppErrorType
    {
        Validation
    }

    public static class ValidationExtensions
    {
        public static Result WithValidationResults(this Result result, List<ValidationFailure> failures, AppErrorType appErrorType = AppErrorType.Validation)
        {
            foreach (var failure in failures)
            {
                var reason = failure.MapToReason(appErrorType);
                result.Reasons.Add(reason);
            }
            return result;
        }

        private static IReason MapToReason(this ValidationFailure failure, AppErrorType appErrorType)
        {
            return appErrorType switch
            {
                AppErrorType.Validation => new ValidationError(failure.PropertyName, failure.ErrorMessage),
                _ => throw new System.NotImplementedException()
            };
        }

        public static ValidationFailureResponse? MapToResponse<T>(this Result<T> result)
        {
            string? message = null;

            if (result.HasError(out IEnumerable<ValidationError> validationErrors))
            {
                message = "Validation error";

            }

            return new ValidationFailureResponse
            {
                Message = message!,
                Errors = validationErrors.Select(x => new ValidationResponse
                {
                    PropertyName = x?.PropertyName!,
                    Message = x?.Message!
                })
            };
        }
    }
}
