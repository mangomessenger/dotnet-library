using System.Threading.Tasks;
using ServicesLibrary.Models.Payload;

namespace ServicesLibrary.Interfaces
{
    public interface IChatService<T>
    {
        Task<T> CreateChatAsync(CreateCommunityPayload payload);
    }
}