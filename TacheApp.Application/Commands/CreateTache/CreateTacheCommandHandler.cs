using TacheApp.Application.Common.Interfaces;
using TacheApp.Application.DTOs;
using TacheApp.Domain.Common;
using TacheApp.Domain.Common.Errors;
using TacheApp.Domain.Entities;
using TacheApp.Domain.Interfaces;

namespace TacheApp.Application.Commands.CreateTache
{
    public class CreateTacheCommandHandler : ICommandHandler<CreateTacheCommand, Result<TacheDto>>
    {
        private readonly ITacheRepository _repository;

        public CreateTacheCommandHandler(ITacheRepository repository)
        {
            _repository = repository;
        }


        public async Task<Result<TacheDto>> HandleAsync(CreateTacheCommand command, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(command.titre))
            {
                return Result<TacheDto>.Failure(DomainErrors.Tache.TitleRequired);
            }
            var entity = new Tache(command.titre);

            _repository.Add(entity);
            await _repository.SaveChangesAsync(ct);
            return Result.Success(new TacheDto(entity.Id, entity.Titre, entity.DateCreation, entity.Realisee));
        }
    }
}
