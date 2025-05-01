namespace Digitalantiz.Common.Domain;

public sealed record ValidationError(Error[] Errors) : Error(
    "General.Validation",
    "One or more validation errors occured",
    ErrorType.Validation)
{
    public static ValidationError FromResults(IEnumerable<Result> results) =>
        new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
}
