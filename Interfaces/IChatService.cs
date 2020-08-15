using System.Threading.Tasks;
using ServicesLibrary.Models.Payload;

namespace ServicesLibrary.Interfaces
{
    public interface IChatService<T>
    {
        T CreateChat(CreateCommunityPayload payload);
        Task<T> CreateChatAsync(CreateCommunityPayload payload);
    }
}