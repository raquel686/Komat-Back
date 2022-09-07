using Inventex.API.Management.Domain.Models;
using Inventex.API.Shared.Domain.Services.Communication;

namespace Inventex.API.Management.Domain.Services.Communication;

public class InventoryResponse : BaseResponse<Inventory>
{
    public InventoryResponse(string message) : base(message){

    }
    public InventoryResponse(Inventory resource) : base(resource){
        
    }
}   