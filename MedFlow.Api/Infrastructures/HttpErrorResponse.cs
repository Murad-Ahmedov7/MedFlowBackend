namespace MedFlow.Api.Infrastructures;

internal record struct HttpErrorResponse
{
    public int Code { get; set; }
    public string Message { get; set; }
    public HttpErrorResponse(string message) : this()
    {
        Code = 0;
        Message = message;
    }

    public HttpErrorResponse(string message, int code) : this(message)
    {
        Code = code;
    }
}
