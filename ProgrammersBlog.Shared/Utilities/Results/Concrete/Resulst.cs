using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Shared.Utilities.Results.Concrete
{
    public class Resulst : IResult
    {
        public Resulst(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Resulst(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        public Resulst(ResultStatus resultStatus, string message, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
        // örnek
        // new Result(ResultStatus.Error, "İşlem Başarısız Oldu", exception)
        // new Result(ResultStatus.Error, exception.message, exception)

    }
}
