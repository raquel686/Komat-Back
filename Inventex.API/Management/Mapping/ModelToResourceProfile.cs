using AutoMapper;
using Inventex.API.Management.Domain.Models;
using Inventex.API.Management.Domain.Services.Communication;
using Inventex.API.Management.Resources;

namespace Inventex.API.Management.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile(){
        CreateMap<Inventory, InventoryResource>();
 
    }
}