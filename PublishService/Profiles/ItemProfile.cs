using AutoMapper;
using PublishService.Dtos;
using PublishService.Models;

namespace PublishService.Profiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<CreateItemDto, Item>();
        CreateMap<Item, ReadItemDto>();
    }
}
