using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MuxomorBot.Services
{
    public interface ICommandExecutor
    {
        Task Execute(Update update);
    }
}