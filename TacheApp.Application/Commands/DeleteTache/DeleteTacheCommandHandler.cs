using TacheApp.Domain.Interfaces;

namespace TacheApp.Application.Commands.DeleteTache
{
    public class DeleteTacheCommandHandler
    {
        private readonly ITacheRepository _repository;

        public DeleteTacheCommandHandler(ITacheRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> HandleAsync(DeleteTacheCommand command, CancellationToken ct = default)
        {
            var entity = await _repository.GetByIdAsync(command.id, ct);
            if (entity == null) return false;


            _repository.Delete(entity);
            return await _repository.SaveChangesAsync(ct);
        }
    }
}
