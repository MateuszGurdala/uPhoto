using MediatR;
using uPhoto.Common.Models;

namespace uPhoto.Common.Contracts;

public interface IApiResponseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, ApiResponse<TResponse>> where TRequest : IRequest<ApiResponse<TResponse>>;
