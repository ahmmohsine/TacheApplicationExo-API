using TacheApp.Application.Common.Interfaces;
using TacheApp.Application.DTOs;
using TacheApp.Domain.Common;
using TacheApp.Domain.Interfaces;

namespace TacheApp.Application.Queries.GetAllTaches
{
    public class GetAllTachesQueryHandler : IQueryHandler<GetAllTachesQuery, Result<IEnumerable<TacheDto>>>
    {
        private readonly ITacheRepository _repository;

        public GetAllTachesQueryHandler(ITacheRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<IEnumerable<TacheDto>>> HandleAsync(GetAllTachesQuery query, CancellationToken ct = default)
        {
            var entities = await _repository.GetAllAsync(ct);

            var dtos = entities.Select(t => new TacheDto(t.Id, t.Titre, t.DateCreation, t.Realisee));
            return Result.Success(dtos);
        }
    }
}
