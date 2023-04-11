using Cars.Domain.Exceptions;

namespace Cars.Application.Exceptions;

public class ValidationException : BaseException
{
    public ValidationException(IDictionary<string, string[]> failures) : base("One or more validation failures have occurred.", failures) { }
}

