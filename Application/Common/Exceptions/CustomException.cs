using System;

namespace Application.Common.Exceptions
{
    public class CustomException : Exception
    {
        // https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions

        public CustomException() { }

        public CustomException(string error) : base(error) { Error = error; }

        public CustomException(string message, Exception inner) : base(message, inner) { }

        public string Error { get; set; }
    }
}