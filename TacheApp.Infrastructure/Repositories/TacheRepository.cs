using Microsoft.EntityFrameworkCore;
using TacheApp.Domain.Entities;
using TacheApp.Domain.Interfaces;
using TacheApp.Infrastructure.Data;

namespace TacheApp.Infrastructure.Repositories
{
    public class TacheRepository : ITacheRepository
    {
        private readonly AppDbContext _context;

        public TacheRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(Tache tache)
        {
            _context.Add(tache);
        }

        public async Task<bool> CloturerAsync(int id, CancellationToken ct = default)
        {
            var entity = await _context.Taches.FindAsync(new object[] { id }, ct);
            if (entity == null) return false;

            entity.Cloturer();

            return await _context.SaveChangesAsync(ct) > 0;
        }

        public void Delete(Tache tache)
        {
            _context.Taches.Remove(tache);
        }
        public async Task<IEnumerable<Tache>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Taches.AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<Tache?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Taches.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }
        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
        public void Update(Tache tache)
        {
            _context.Taches.Update(tache);
        }
    }
}
