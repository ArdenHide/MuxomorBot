using MuxomorBot.Data.Entities;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MuxomorBot.Services
{
    public interface IUserService
    {
        Task<AppUser> GetOrCreate(Update update);
    }
}
