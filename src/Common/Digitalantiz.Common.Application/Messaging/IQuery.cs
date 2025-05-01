using Digitalantiz.Common.Domain;
using MediatR;

namespace Digitalantiz.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
