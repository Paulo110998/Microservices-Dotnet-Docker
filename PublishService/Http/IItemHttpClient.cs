using PublishService.Dtos;

namespace PublishService.Http;

public interface IItemHttpClient
{
    void SendItem(ReadItemDto readItemDto);
}
