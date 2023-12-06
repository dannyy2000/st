namespace WebApplication1.exceptions;

public class StockNotFoundException:Exception
{
    public StockNotFoundException(string message) : base(message)
    {
    }
}