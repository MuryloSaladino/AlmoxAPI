using Almox.Application.Repository;
using AutoMapper;

namespace Almox.Application.Common.Behaviors;

public class MapperBehavior : Profile
{
    public MapperBehavior()
    {
        CreateMap(typeof(PaginatedResult<>), typeof(PaginatedResult<>));
    }
}