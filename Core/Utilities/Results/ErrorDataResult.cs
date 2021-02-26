using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        // yine default olarak false döndürmüş olduk...
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)
        // datayı default haliyle döndürmek için...
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
