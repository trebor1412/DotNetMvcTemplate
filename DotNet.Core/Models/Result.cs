namespace DotNet.Core
{
    public class Result : IResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }

    public class Result<T> : Result, IResult
    {
        public T Data { get; set; }
    }
}