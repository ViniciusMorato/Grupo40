namespace Core.Exceptions;

public sealed class UserAlreadyExistsException : DomainException
{
    public UserAlreadyExistsException(string message) : base(message)
    {
    }
}