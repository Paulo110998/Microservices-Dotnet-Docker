using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PublishService.Data;
using PublishService.Dtos;
using PublishService.Http;
using PublishService.Models;

namespace PublishService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;
    private IItemHttpClient _itemHttpClient;
    //private IRabbitMqClient _rabbitMqClient;

    public ItemController(IItemRepository itemRepository, 
        IMapper mapper, IItemHttpClient itemHttpClient)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
        _itemHttpClient = itemHttpClient;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReadItemDto>> GetAll()
    {
        var items = _itemRepository.GetAllItems();

        return Ok(_mapper.Map<IEnumerable<ReadItemDto>>(items));
    }

    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<ReadItemDto> GetById(int id)
    {
        var item = _itemRepository.GetItemById(id);
        if (item != null)
        {
            return Ok(_mapper.Map<ReadItemDto>(item));
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<ReadItemDto>> CreateItem(CreateItemDto createItemDto)
    {
        var item = _mapper.Map<Item>(createItemDto);
       _itemRepository.CreateItem(item);
        _itemRepository.SaveChanges();

        var readItemDto = _mapper.Map<ReadItemDto>(item);

        //_rabbitMqClient.PublishItem(readItemDto);

       _itemHttpClient.SendItem(readItemDto); // linha 58

        return CreatedAtRoute(nameof(GetById), 
            new {readItemDto.Id}, readItemDto);
    }

       
   





}
