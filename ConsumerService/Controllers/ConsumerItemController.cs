using AutoMapper;
using ConsumerService.Data;
using ConsumerService.Dtos;
using ConsumerService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsumerItemController : ControllerBase
{
    private readonly IItemRepository _repository;
    private readonly IMapper _mapper;

    public ConsumerItemController(IItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReadItemDto>> GetAll()
    {
        var items = _repository.GetAllItems();

        return Ok(_mapper.Map<IEnumerable<ReadItemDto>>(items));
    }

    [HttpPost]
    public ActionResult<ReadItemDto> CreateItem(CreateItemDto createItemDto)
    {
        var item = _mapper.Map<Item>(createItemDto);
        _repository.AddItem(item);
        _repository.SaveChanges();

        var readItemDto = _mapper.Map<ReadItemDto>(item);

        return CreatedAtAction(nameof(GetAll), new { id = readItemDto.Id }, readItemDto);
    }

}
