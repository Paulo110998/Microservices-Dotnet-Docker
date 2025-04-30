using AutoMapper;
using ConsumerService.Dtos;
using ConsumerService.Models;

namespace ConsumerService.Profiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Item, ReadItemDto>();
        CreateMap<CreateItemDto, Item>();
    }
}
