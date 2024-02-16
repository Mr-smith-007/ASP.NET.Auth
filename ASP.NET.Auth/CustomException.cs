using System;

namespace ASP.NET.Auth
{
    public class CustomException :Exception
    {
        public CustomException(string message) : base(message) 
        {
            
        }
    }
}
