using ServicesLibrary.Enums;

namespace ServicesLibrary.Interfaces.Chat
{
    public interface IChat
    {
        public int Id { get; set; }
        public ChatTypeEnum ChatType { get; set; }
    }
}