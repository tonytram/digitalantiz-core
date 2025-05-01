using Digitalantiz.Common.Domain;
using MediatR;

namespace Digitalantiz.Common.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
