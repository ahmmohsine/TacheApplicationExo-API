using TacheApp.Application.Common.Interfaces;
using TacheApp.Domain.Common;
using TacheApp.Domain.Common.Errors;
using TacheApp.Domain.Interfaces;

namespace TacheApp.Application.Commands.DeleteTache
{
    public class DeleteTacheCommandHandler : ICommandHandler<DeleteTacheCommand, Result<bool>>
    {
        private readonly ITacheRepository _repository;

        public DeleteTacheCommandHandler(ITacheRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<bool>> HandleAsync(DeleteTacheCommand command, CancellationToken ct)
        {
            var entity = await _repository.GetByIdAsync(command.id, ct);
            if (entity == null) return Result.Failure<bool>(DomainErrors.Tache.NotFound);


            _repository.Delete(entity);
            await _repository.SaveChangesAsync(ct);
            return Result.Success(true);

        }
    }
}
