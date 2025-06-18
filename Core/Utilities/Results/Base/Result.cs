using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Base
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)
        {
            this.success = success;
            this.responseText = message;
        }

        public Result(bool success)
        {
            this.success = success;
        }

        public bool success { get; }

        public string responseText { get; }
    }
}
