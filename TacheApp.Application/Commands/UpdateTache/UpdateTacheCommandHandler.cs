using TacheApp.Application.Common.Interfaces;
using TacheApp.Domain.Common;
using TacheApp.Domain.Common.Errors;
using TacheApp.Domain.Interfaces;

namespace TacheApp.Application.Commands.UpdateTache
{
    public class UpdateTacheCommandHandler : ICommandHandler<UpdateTacheCommand, Result>
    {
        private readonly ITacheRepository _repository;

        public UpdateTacheCommandHandler(ITacheRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> HandleAsync(UpdateTacheCommand command, CancellationToken ct = default)
        {

            var entity = await _repository.GetByIdAsync(command.Id, ct);
            if (entity is null)
            {
                return Result.Failure(DomainErrors.Tache.NotFound);
            }
            var updateResult = entity.Update(command.Titre, command.Realisee);
            if (updateResult.IsFailure)
            {
                return updateResult;
            }

            await _repository.SaveChangesAsync(ct);
            return Result.Success();
        }
    }
}
