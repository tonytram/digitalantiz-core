using Digitalantiz.Common.Domain;

namespace Digitalantiz.Common.Application.Exceptions;

public sealed class DigitalantizException(
    string requestName,
    Error? error = default,
    Exception? innerException = default)
    : Exception("Application exception", innerException)
{
    public string RequestName { get; set; } = requestName;

    public Error? Error { get; set; } = error;
}
