using AutoMapper;
using Inventex.API.Security.Domain.Models;
using Inventex.API.Security.Domain.Services.Communication;
using Inventex.API.Security.Resources;

namespace Inventex.API.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}