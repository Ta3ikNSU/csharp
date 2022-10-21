namespace lab2.Exception;

public class UnknownContenderException : System.Exception
{
    public UnknownContenderException()
    {
    }

    public UnknownContenderException(string message)
        : base(message)
    {
    }

    public UnknownContenderException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}