
using GroupChat7.Models;

namespace GroupChat7.Controllers.dataTransferObject
{
    public class CreateMessage
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}
