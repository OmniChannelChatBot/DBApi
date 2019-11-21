using System.Threading.Tasks;
using DBApi.Interface;
using DBApi.Model.Chat;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DBApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class ChatRoomController : Controller
    {
        private readonly IChatRoomService _chatRoomService;

        public ChatRoomController(IChatRoomService chatRoomService)
        {
            _chatRoomService = chatRoomService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var chatRooms = await _chatRoomService.GetChatRoomsAsync();

            return Ok(chatRooms);
        }

        // GET: api/values
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAsync(int userId)
        {
            var chatRooms = await _chatRoomService.GetChatRoomsAsync(userId);

            return Ok(chatRooms);
        }

        // POST api/values
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]ChatRoom chatRoom)
        {
            var result = await _chatRoomService.AddChatRoomAsync(chatRoom);

            return Ok(result);
        }
    }
}
