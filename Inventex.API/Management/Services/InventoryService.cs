using Inventex.API.Management.Domain.Models;
using Inventex.API.Management.Domain.Repositories;
using Inventex.API.Management.Domain.Services;
using Inventex.API.Management.Domain.Services.Communication;
using Inventex.API.Security.Domain.Repositories;
using Inventex.API.Shared.Domain.Repositories;
using Inventex.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Inventex.API.Management.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public InventoryService(IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _inventoryRepository = inventoryRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async  Task<IEnumerable<Inventory>> ListAsync()
    {
        return await _inventoryRepository.ListAsync();
    }
    public async Task<IEnumerable<Inventory>> ListByUserIdAsync(int userId)
    {
        return await _inventoryRepository.FindByUserIdAsync(userId);
    }

    //POST
    public async Task<InventoryResponse> SaveAsync(Inventory inventory)
    {
        //Validate Inventory Id
        var existingUser = await _userRepository.FindByIdAsync(inventory.UserId);
        
        if (existingUser == null)
            return new InventoryResponse("Invalid User");
        
        //Validate Inventory Name

        try
        {
            
            await _inventoryRepository.AddAsync(inventory);
            await _unitOfWork.CompleteAsync();
            return new InventoryResponse(inventory);
        }
        catch (Exception e)
        {
            return new InventoryResponse($"An error occurred while saving the product: {e.Message} ");
        }
    }

    //PUT
    public async Task<InventoryResponse> UpdateAsync(int inventoryId, Inventory inventory)
    {
        var existingInventory = await _inventoryRepository.FindByIdAsync(inventoryId);
        
        //Validation
        if (existingInventory == null)
            return new InventoryResponse("Product not found");
        
        //Validate userid
        var existingUser = await _userRepository.FindByIdAsync(inventory.UserId);

        if (existingUser == null )
            return new InventoryResponse("Invalid USer");

        existingInventory.Name = inventory.Name;
        existingInventory.Price = inventory.Price;
        existingInventory.Image = inventory.Image;
        existingInventory.Category = inventory.Category;

        try
        {
            _inventoryRepository.Update(existingInventory);
            await _unitOfWork.CompleteAsync();

            return new InventoryResponse(existingInventory);
        }
        catch (Exception e)
        {
            return new InventoryResponse($"An error occurred while updating the product: {e.Message}");
        }
    }
    
    //DELETE
    public async  Task<InventoryResponse> DeleteAsync(int inventoryId)
    {
        var existingInventory = await _inventoryRepository.FindByIdAsync(inventoryId);
        //Validation
        if (existingInventory == null)
            return new InventoryResponse("Product not found");
        try
        {
            _inventoryRepository.Remove(existingInventory);
            await _unitOfWork.CompleteAsync();

            return new InventoryResponse(existingInventory);
        }
        catch (Exception e)
        {
            return new InventoryResponse($"An error occurred while deleting  the product: {e.Message}");
        }
    }
}