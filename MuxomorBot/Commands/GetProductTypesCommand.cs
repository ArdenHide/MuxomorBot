using MuxomorBot.Data;
using MuxomorBot.Data.Entities;
using MuxomorBot.Keyboards;
using MuxomorBot.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace MuxomorBot.Commands
{
    public class GetProductTypesCommand : BaseCommand
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly DataContext _context;
        private readonly TelegramBotClient _botClient;

        public GetProductTypesCommand(IUserService userService,
            TelegramBot telegramBot,
            IProductService product, DataContext context)
        {
            _context = context;
            _userService = userService;
            _productService = product;
            _botClient = telegramBot.GetBot().Result;
        }

        public override string Name => CommandNames.GetProductTypes;

        public override async Task ExecuteAsync(Update update)
        {
            var user = await _userService.GetOrCreate(update);
            string productName = update.Message.Text;
            var category = _context.Categories.FirstOrDefault(x => x.DisplayName == productName);
            var products = _context.Products.Where(x => x.CategoryId == category.Id).ToList();

            string filePath = $@"src\img\{category.Name}\preview.png";
            using FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();

            await _botClient.SendPhotoAsync(user.ChatId,
                photo: new InputOnlineFile(fileStream, fileName),
                caption: "Выберите категорию",
                ParseMode.Markdown,
                replyMarkup: DynamicKeyboard.ProductTypesKeyboard(products));
        }
    }
}
