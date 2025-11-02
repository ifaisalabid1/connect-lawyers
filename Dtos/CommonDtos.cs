namespace ConnectLawyers.Dtos;

public record PagedResult<T>(IEnumerable<T> Items, int TotalCount, int Page, int PageSize);

public class ValidationError
{
    public string PropertyName { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
}

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<ValidationError>? Errors { get; set; }

    public static ApiResponse<T> Ok(T data, string message = "") => new()
    {
        Success = true,
        Data = data,
        Message = message
    };

    public static ApiResponse<T> Fail(string message, List<ValidationError>? errors = null) => new()
    {
        Success = false,
        Message = message,
        Errors = errors
    };
}
