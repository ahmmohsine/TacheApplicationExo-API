using TacheApp.Domain.Interfaces;

namespace TacheApp.Application.Commands.ClotureTache
{
    public class ClotureTacheCommandHandler
    {
        private readonly ITacheRepository _repository;

        public ClotureTacheCommandHandler(ITacheRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> HandleAsync(ClotureTacheCommand command, CancellationToken ct = default)
        {
            return await _repository.CloturerAsync(command.id);
        }
    }
}
