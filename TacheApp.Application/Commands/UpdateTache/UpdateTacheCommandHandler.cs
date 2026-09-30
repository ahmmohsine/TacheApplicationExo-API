using TacheApp.Domain.Interfaces;

namespace TacheApp.Application.Commands.UpdateTache
{
    public class UpdateTacheCommandHandler
    {
        private readonly ITacheRepository _repository;

        public UpdateTacheCommandHandler(ITacheRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> HandleAsync(UpdateTacheCommand command, CancellationToken ct = default)
        {
            var entity = await _repository.GetByIdAsync(command.Id, ct);
            if (entity == null) return false;

            entity.Titre = command.Titre;
            entity.Realisee = command.Realisee;

            _repository.Update(entity);
            return await _repository.SaveChangesAsync(ct);
        }
    }
}
