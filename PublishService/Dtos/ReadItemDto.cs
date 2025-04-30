using System.ComponentModel.DataAnnotations;

namespace PublishService.Dtos;

public class ReadItemDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
