using TacheApp.Application.DTOs;
using TacheApp.Domain.Entities;
using TacheApp.Domain.Interfaces;

namespace TacheApp.Application.Queries.GetTacheById
{
    public class GetTacheByIdQueryHandler
    {
        private readonly ITacheRepository _repository;

        public GetTacheByIdQueryHandler(ITacheRepository repository)
        {
            _repository = repository;
        }
        public async Task<TacheDto> HandleAsync(GetTacheByIdQuery query, CancellationToken cancellation)
        {
            Tache? tache = await _repository.GetByIdAsync(query.Id, cancellation);
            if (tache is null)
                return null;


            return new TacheDto(tache.Id, tache.Titre, tache.DateCreation, tache.Realisee);

        }
    }
}
