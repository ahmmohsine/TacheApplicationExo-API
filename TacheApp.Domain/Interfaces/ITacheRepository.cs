using TacheApp.Domain.Entities;

namespace TacheApp.Domain.Interfaces
{
    public interface ITacheRepository
    {
        Task<IEnumerable<Tache>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Tache?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> CloturerAsync(int id, CancellationToken cancellationToken = default);
        void Add(Tache tache);
        void Update(Tache tache);
        void Delete(Tache tache);
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}

