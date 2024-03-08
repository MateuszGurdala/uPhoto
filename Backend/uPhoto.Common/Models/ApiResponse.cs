using System.Net;

namespace uPhoto.Common.Models;

public class ApiResponse<TValue>
{
	public HttpStatusCode Status { get; protected set; }
	public string? Errors { get; protected set; }
	public TValue? Data { get; protected set; }


	public static ApiResponse<TValue> Success(TValue data) => new() { Data = data, Status = HttpStatusCode.OK };
	public static ApiResponse<TValue> Success() => new() { Status = HttpStatusCode.OK };

	public static ApiResponse<TValue> Failed(string errors, HttpStatusCode status = HttpStatusCode.InternalServerError) => new() { Errors = errors, Status = status };
}
