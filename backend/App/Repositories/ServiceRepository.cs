using App.DB;
using App.Entities;
using Microsoft.EntityFrameworkCore;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _ctx;
    public ServiceRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<IEnumerable<Service>> GetAllAsync() =>
        await _ctx.Services
                  .Include(s => s.User)
                  .AsNoTracking()
                  .ToListAsync();
}