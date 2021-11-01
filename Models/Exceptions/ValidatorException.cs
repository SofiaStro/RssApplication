using System;

namespace Models.Exceptions
{
    public class ValidatorException : Exception
    {
        public ValidatorException(string message) : base(message) { }
    }
}
