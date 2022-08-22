using Microsoft.EntityFrameworkCore;
using MuxomorBot.Data;
using MuxomorBot.Data.Entities;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MuxomorBot.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetOrCreate(Update update)
        {
            var newUser = update.Type switch
            {
                UpdateType.CallbackQuery => new AppUser
                {
                    ChatId = update.CallbackQuery.Message.Chat.Id,
                    UserName = update.CallbackQuery.From.Username,
                    FirstName = update.CallbackQuery.Message.From.FirstName,
                    LastName = update.CallbackQuery.Message.From.LastName
                },
                UpdateType.Message => new AppUser
                {
                    UserName = update.Message.Chat.Username,
                    ChatId = update.Message.Chat.Id,
                    FirstName = update.Message.Chat.FirstName,
                    LastName = update.Message.Chat.LastName
                }
            };

            var user = await _context.Users.FirstOrDefaultAsync(x => x.ChatId == newUser.ChatId);

            if (user != null) return user;

            var result = await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
