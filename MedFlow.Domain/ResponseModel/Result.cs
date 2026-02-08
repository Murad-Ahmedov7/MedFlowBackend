namespace Domain.ResponseModel;

public class Result
{
    public bool IsSuccess { get; set; }

    public List<string>? Errors { get; set; }

    public Result(List<string> messages)
    {
        Errors = messages;
        IsSuccess = false;
    }

    public Result()
    {
        IsSuccess = true;
        Errors = null;
    }
}

public class Result<T> : Result
{
    public T? Data { get; set; }

    public Result(List<string> messages) : base(messages) { }

    public Result() { }
}
