using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroupChat7.Models;

    public class GroupChatContext : DbContext
    {
        public GroupChatContext (DbContextOptions<GroupChatContext> options)
            : base(options)
        {
        }

        public DbSet<GroupChat7.Models.Message> Message { get; set; } = default!;
        public DbSet<GroupChat7.Models.Group> Group { get; set; } = default!;
        public DbSet<GroupChat7.Models.User> User { get; set; } = default!;
        public DbSet<GroupChat7.Models.UserGroup> UserGroup { get; set; } = default!;
}
