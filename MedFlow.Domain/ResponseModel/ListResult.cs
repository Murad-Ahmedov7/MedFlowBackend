namespace Domain.ResponseModel;

public class ListResult<T> : Result
{
    int _count = 0;
    List<T> _data = [];
    public int TotalCount { get { return _count; } }

    public List<T> Data
    {
        get { return _data; }
        set
        {
            _data = value;
            _count = _data.Count;
        }
    }
    public ListResult(List<string> errors) : base(errors) { }
    public ListResult() { }
}
