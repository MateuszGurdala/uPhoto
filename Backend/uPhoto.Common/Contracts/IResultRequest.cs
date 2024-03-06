using MediatR;
using uPhoto.Common.Models;

namespace uPhoto.Common.Contracts;

public interface IResultRequest<TType> : IRequest<ApiResponse<TType>>;
