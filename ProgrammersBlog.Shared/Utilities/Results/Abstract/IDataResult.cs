using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult // <out T> => 
    {
        public T Data { get;} // new DataResult<Category>(ResultStatus.Success, category); normal bir category olabilir
                              // new DataResult<IList<Category>>(ResultStatus.Success, category);  veya bir liste olabilir

    }
}
