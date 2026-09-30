using TacheApp.Application.DTOs;
using TacheApp.Domain.Entities;
using TacheApp.Domain.Interfaces;

namespace TacheApp.Application.Commands.CreateTache
{
    public class CreateTacheCommandHandler
    {
        private readonly ITacheRepository _repository;

        public CreateTacheCommandHandler(ITacheRepository repository)
        {
            _repository = repository;
        }


        public async Task<TacheDto> HandleAsync(CreateTacheCommand command, CancellationToken ct = default)
        {
            var entity = new Tache
            {
                Titre = command.titre
            };

            _repository.Add(entity);
            await _repository.SaveChangesAsync(ct);
            return new TacheDto(entity.Id, entity.Titre, entity.DateCreation, entity.Realisee);
        }
    }
}
