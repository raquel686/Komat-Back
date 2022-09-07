using AutoMapper;
using Inventex.API.Management.Domain.Models;
using Inventex.API.Management.Resources;
using Inventex.API.Security.Domain.Models;

namespace Inventex.API.Management.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile(){
     
        CreateMap<SaveInventoryResource, Inventory>();
        
    }
}