using System.ComponentModel.DataAnnotations;

namespace PublishService.Dtos;

public class CreateItemDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

}
