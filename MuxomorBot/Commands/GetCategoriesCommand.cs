using MuxomorBot.Keyboards;
using MuxomorBot.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MuxomorBot.Commands
{
    public class GetCategoriesCommand : BaseCommand
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly TelegramBotClient _botClient;

        public GetCategoriesCommand(IUserService userService,
            IProductService productService,
            TelegramBot telegramBot)
        {
            _userService = userService;
            _productService = productService;
            _botClient = telegramBot.GetBot().Result;
        }

        public override string Name => CommandNames.GetCategories;

        public override async Task ExecuteAsync(Update update)
        {
            var user = await _userService.GetOrCreate(update);
            var categories = await _productService.GetCategoriesAsync();

            await _botClient.SendTextMessageAsync(
                user.ChatId,
                text: $"Выберите товар",
                replyMarkup: CategoriesKeyboard.GetDynamicReplyKeyboard(categories));
        }
    }
}
