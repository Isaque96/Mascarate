using System;

namespace Mascarate.Exceptions
{
    public class MissingValuesException : Exception
    {
        public MissingValuesException()
            : base("The input value length does not match the number of mask placeholders.") { }
        
        public MissingValuesException(string message) : base(message) { }

        public MissingValuesException(string message, Exception inner) : base(message, inner) { }
    }
}