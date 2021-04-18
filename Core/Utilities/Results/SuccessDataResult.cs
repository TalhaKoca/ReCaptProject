using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data,true,message)
            // yine default olarak true döndürmüş olduk...
        {

        }
        public SuccessDataResult(T data):base(data,true)
        {

        }
        public SuccessDataResult(string message):base(default,true,message)
            // datayı default haliyle döndürmek için...
        {

        }
        public SuccessDataResult():base(default,true)
        {

        }
    }
}
