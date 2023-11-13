// createGroup, AddUserToGroup,GetGroupName

using GroupChat7.Controllers.dataTransferObject;
using GroupChat7.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroupChat7.Controllers
{
    [ApiController]
    [Route("api/Group/")]
    public class GroupController : ControllerBase
    {
        private readonly GroupChatContext _context;
        public GroupController(GroupChatContext context)
        {
            _context = context;
        }

        [HttpPost("CreateGroup")]
        public async Task<IActionResult> CreateGroup([FromBody] GroupCreationModel groupData)
        {
            if (string.IsNullOrEmpty(groupData.GroupName))
            {
                return BadRequest("Group name cannot be empty.");
            }

            var group = new Models.Group { GroupName = groupData.GroupName };
            _context.Group.Add(group);

            if (groupData.SelectedUsers != null && groupData.SelectedUsers.Count > 0)
            {
                var users = _context.User.Where(u => groupData.SelectedUsers.Contains(u.Username)).ToList();
                foreach (var user in users)
                {
                    if (group != null && user != null)
                    {
                        if (group.UserGroups == null)
                        {
                            group.UserGroups = new List<UserGroup>();
                        }

                        group.UserGroups.Add(new UserGroup { User = user, Group = group });
                    }
                }
            }

            await _context.SaveChangesAsync();
            return Ok("Group added: " + group.GroupName);
        }

        [HttpPost("AddUserToGroup")]
        public async Task<IActionResult> AddUserToGroup([FromBody] int userId, int groupId)
        {
            var userGroup = new UserGroup { UserId = userId, GroupId = groupId };
            _context.UserGroup.Add(userGroup);
            await _context.SaveChangesAsync();
            return Ok("User added to group: " + userGroup);
        }

       
    }
}
