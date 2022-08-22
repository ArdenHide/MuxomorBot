using MuxomorBot.Data;
using MuxomorBot.Keyboards;
using MuxomorBot.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MuxomorBot.Commands
{
    public class StartCommand : BaseCommand
    {
        private readonly IUserService _userService;
        private readonly TelegramBotClient _botClient;

        public StartCommand(IUserService userService, TelegramBot telegramBot, DataContext context)
        {
            _userService = userService;
            _botClient = telegramBot.GetBot().Result;
        }

        public override string Name => CommandNames.Start;

        public override async Task ExecuteAsync(Update update)
        {
            var user = await _userService.GetOrCreate(update);

            await _botClient.SendTextMessageAsync(user.ChatId, text: $"Привет, {user.FirstName}!" +
                "\nЯ бот созданный что бы помочь тебе сделать заказ - Мухомора." +
                "\nМухомор является одним из лучших лекарств от таких болезней как депрессия, алкогольная зависимость, вирусные(вич) и многих других, а также инструментом способствующим достижению целей и увеличению энергетики.",
                ParseMode.Markdown, replyMarkup: MainKeyboard.ReplyKeyboard());
        }
    }
}
