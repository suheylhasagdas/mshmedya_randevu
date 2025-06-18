using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Base
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(bool success, string message, T data) : base(success, message)
        {
            this.data = data;
        }

        public DataResult(bool success, T data):base(success)
        {
            this.data = data;
        }

        public T data { get; }
    }
}
