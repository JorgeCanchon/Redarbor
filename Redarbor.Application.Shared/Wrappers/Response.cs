using System.Text.Json.Serialization;

namespace Redarbor.Application.Shared.Wrappers;

public class Response<T>
{
    public bool IsSucess { get; set; }
    public string? Message { get; set; }
    public string? Code { get; set; }
    public T? Result { get; set; }
    public List<string>? Errors { get; set; }

    [JsonConstructor]
    public Response(T result, bool isSucess, string message)
    {
        Result = result;
        IsSucess = isSucess;
        Message = message;
    }

    public Response(T result, string? message = null)
    {
        IsSucess = true;
        Message = message;
        Result = result;
    }

    public Response(string? message = null)
    {
        IsSucess = false;
        Message = message;
    }
}