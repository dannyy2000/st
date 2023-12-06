using System.Net;

namespace WebApplication1.exceptions;

public class UserException:Exception
{
    public UserException(string message,HttpStatusCode httpStatusCode): base(message)
    {
    }
    public UserException(string message): base(message)
    {
    }
    
    public UserException(HttpStatusCode httpStatusCode)
    {
    }
}