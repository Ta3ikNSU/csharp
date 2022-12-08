namespace lab4.Exception;

public class GenerateEnvironException : System.Exception
{
    public GenerateEnvironException()
    {
    }

    public GenerateEnvironException(string message)
        : base(message)
    {
    }

    public GenerateEnvironException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}