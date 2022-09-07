using Inventex.API.Management.Domain.Models;
using Inventex.API.Management.Domain.Services.Communication;

namespace Inventex.API.Management.Domain.Services;

public interface IInventoryService
{
    Task<IEnumerable<Inventory>> ListAsync();
    Task<IEnumerable<Inventory>> ListByUserIdAsync(int userId);
    Task<InventoryResponse> SaveAsync(Inventory inventory);
    Task<InventoryResponse> UpdateAsync(int id, Inventory inventory);
    Task<InventoryResponse> DeleteAsync(int id);
    
}