using System.ComponentModel.DataAnnotations;

namespace ConsumerService.Dtos;

public class CreateItemDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }
}