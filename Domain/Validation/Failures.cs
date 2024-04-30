using FluentResults;

namespace HicomInterview.Validation
{
    /// <summary>
    /// Extend FluentResults.Error to include PropertyName & Message similar to ModelState.Error
    /// </summary>
    public class ValidationError : Error, IFailure
    {
        public string PropertyName { get; }

        public ValidationError(string propertyName, string message)
            : this(message)
        {
            PropertyName = propertyName;
        }

        public ValidationError(string message)
        {
            PropertyName = string.Empty;
            Message = message;
        }
    }

    public interface IFailure
    {
        string PropertyName { get; }
        string Message { get; }
    }

    public class ValidationFailureResponse
    {
        public required string Message { get; init; }
        public required IEnumerable<ValidationResponse> Errors { get; init; }
    }

    public class ValidationResponse
    {
        public required string PropertyName { get; init; }

        public required string Message { get; init; }
    }
}
