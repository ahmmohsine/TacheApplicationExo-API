using TacheApp.Application.Common.Interfaces;
using TacheApp.Application.DTOs;
using TacheApp.Domain.Common;
using TacheApp.Domain.Common.Errors;
using TacheApp.Domain.Interfaces;

namespace TacheApp.Application.Queries.GetTacheById
{
    public class GetTacheByIdQueryHandler : IQueryHandler<GetTacheByIdQuery, Result<TacheDto>>
    {
        private readonly ITacheRepository _repository;
        public GetTacheByIdQueryHandler(ITacheRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<TacheDto>> HandleAsync(GetTacheByIdQuery query, CancellationToken cancellation = default)
        {
            var tache = await _repository.GetByIdAsync(query.Id, cancellation);
            if (tache is null)
                return Result<TacheDto>.Failure(DomainErrors.Tache.NotFound);
            return Result<TacheDto>.Success(new TacheDto(tache.Id, tache.Titre, tache.DateCreation, tache.Realisee));
        }
    }
}
