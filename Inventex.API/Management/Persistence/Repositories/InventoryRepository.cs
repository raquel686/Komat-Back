using Inventex.API.Management.Domain.Models;
using Inventex.API.Management.Domain.Repositories;
using Inventex.API.Shared.Persistence.Contexts;
using Inventex.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventex.API.Management.Persistence.Repositories;

public class InventoryRepository : BaseRepository, IInventoryRepository
{
    public InventoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Inventory>> ListAsync()
    {
        //Get tutorial and for each populate the object
        return await _context.Inventories
            .Include(p => p.User).
            ToListAsync();
    }

    public async Task AddAsync(Inventory inventory)
    {
        await _context.Inventories.AddAsync(inventory);
    }

    public async Task<Inventory> FindByIdAsync(int inventoryId)
    {
        return await _context.Inventories
            .Include(p=>p.User)
            .FirstOrDefaultAsync(p=>p.Id==inventoryId);
    }
    public async Task<Inventory> FindByNameAsync(string name)
    {
        return await _context.Inventories
            .Include(p=>p.User)
            .FirstOrDefaultAsync(p=>p.Name==name);
    }
    
    public async Task<IEnumerable<Inventory>> FindByUserIdAsync(int userId)
    {
        return await _context.Inventories
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }

    
    public void Update(Inventory inventory)
    {
        _context.Inventories.Update(inventory);
    }

    public void Remove(Inventory inventory)
    {
        _context.Inventories.Remove(inventory);
    }
}