namespace Domain.ResponseModel;



// Əməliyyatların nəticəsini standart şəkildə təmsil etmək üçün istifadə olunur.
// Uğurlu və uğursuz nəticələri, eləcə də xəta mesajlarını idarə edir.


// Used to represent operation results in a standardized way.
// Handles both successful and failed outcomes, including error messages.
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


// Data qaytaran əməliyyatların nəticəsini təmsil edir.
// Result sinfinin generic versiyasıdır və əlavə olaraq data saxlayır.


// Represents the result of operations that return data.
// Generic version of Result that also carries the returned data.
public class Result<T> : Result
{
    public T? Data { get; set; }

    public Result(List<string> messages) : base(messages) { }

    public Result() { }
}
