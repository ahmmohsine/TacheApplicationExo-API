using TacheApp.Application.DTOs;
using TacheApp.Domain.Interfaces;

namespace TacheApp.Application.Queries.GetAllTaches
{
    public class GetAllTachesQueryHandler
    {
        private readonly ITacheRepository _repository;

        public GetAllTachesQueryHandler(ITacheRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<TacheDto>> HandleAsync(GetAllTachesQuery query, CancellationToken ct = default)
        {
            var entities = await _repository.GetAllAsync(ct);
            return entities.Select(t => new TacheDto(t.Id, t.Titre, t.DateCreation, t.Realisee));
        }
    }
}
