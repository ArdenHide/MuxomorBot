using MuxomorBot.Data.Entities.Products;
using Telegram.Bot.Types.ReplyMarkups;

namespace MuxomorBot.Keyboards
{
    public static class BuyWholeCapsKeyboard
    {
        public static InlineKeyboardMarkup InlineKeyboard()
        {
            return new InlineKeyboardMarkup(new[]
            {
                new [] {
                    InlineKeyboardButton.WithCallbackData(ButtonText.BuyOpenedWholeCaps, ProductType.WholeCaps.ToString()),
                    InlineKeyboardButton.WithCallbackData(ButtonText.BuyUnopenedWholeCaps, ProductType.WholeCaps.ToString()),
                },
                new[] {
                    InlineKeyboardButton.WithCallbackData(ButtonText.BuyPantherWholeCaps, ProductType.WholeCaps.ToString()),
                    InlineKeyboardButton.WithCallbackData(ButtonText.BuyVipWholeCaps, ProductType.WholeCaps.ToString()),
                }
            });
        }
    }
}
