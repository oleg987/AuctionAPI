namespace AuctionAPI.Exceptions;

public class CustomValidationException : Exception
{
    public ValidationDetails Details { get; }

    public CustomValidationException()
    {
        Details = new();
    }

    public CustomValidationException(IEnumerable<ValidationError> errors)
    {
        Details = new(errors);
    }

    public CustomValidationException(ValidationError error)
    {
        Details = new(error);
    }
}

public class ValidationDetails
{
    private readonly List<ValidationError> _errors = [];

    public IReadOnlyList<ValidationError> Errors => _errors;

    public ValidationDetails()
    {
        
    }

    public ValidationDetails(IEnumerable<ValidationError> errors)
    {
        _errors.AddRange(errors);
    }

    public ValidationDetails(ValidationError error)
    {
        _errors.Add(error);
    }
}

public class ValidationError
{
    public string Target { get; }
    public string Description { get; }

    public ValidationError(string target, string description)
    {
        Target = target;
        Description = description;
    }
}