using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)
            // public Pascal Case
        {

        }
        public ErrorResult() : base(false)
        // false default olarak vermiş olduk...
        {

        }
    }
}
