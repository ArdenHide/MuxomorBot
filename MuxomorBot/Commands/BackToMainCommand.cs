using MuxomorBot.Keyboards;
using MuxomorBot.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MuxomorBot.Commands
{
    public class BackToMainCommand : BaseCommand
    {
        private readonly IUserService _userService;
        private readonly TelegramBotClient _botClient;

        public BackToMainCommand(IUserService userService, TelegramBot telegramBot)
        {
            _userService = userService;
            _botClient = telegramBot.GetBot().Result;
        }

        public override string Name => CommandNames.BackToMain;

        public override async Task ExecuteAsync(Update update)
        {
            var user = await _userService.GetOrCreate(update);
            
            await _botClient.SendTextMessageAsync(user.ChatId,
                text: $"Привет, {user.FirstName}!" +
                "\nЧем я могу тебе помочь?",
                ParseMode.Markdown,
                replyMarkup: MainKeyboard.ReplyKeyboard());
        }
    }
}
