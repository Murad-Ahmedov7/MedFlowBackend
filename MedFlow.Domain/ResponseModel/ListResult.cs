using System.Collections.Generic;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.ResponseModel;


// List datasını encapsulation ilə qoruyur və TotalCount-un Data.Count ilə
// həmişə uyğun qalmasını təmin edir.

// Encapsulates list data and ensures TotalCount always stays in sync
// with the number of items in Data.

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
