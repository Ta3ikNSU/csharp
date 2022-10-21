namespace lab2.Exception;

public class HallEmptyException : System.Exception
{
    public HallEmptyException()
    {
    }

    public HallEmptyException(string message)
        : base(message)
    {
    }

    public HallEmptyException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}