namespace Kernel.Contracts.Exceptions
{
    using System;

    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException()
        {
        }

        public ForbiddenAccessException(string? message)
            : base(message)
        {
        }

        public ForbiddenAccessException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
