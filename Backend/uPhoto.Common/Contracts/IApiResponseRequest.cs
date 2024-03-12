using MediatR;
using uPhoto.Common.Models;

namespace uPhoto.Common.Contracts;

public interface IApiResponseRequest<TType> : IRequest<ApiResponse<TType>>;
