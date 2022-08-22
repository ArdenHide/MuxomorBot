using MuxomorBot.Data;
using MuxomorBot.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types.ReplyMarkups;

namespace MuxomorBot.Keyboards
{
    public static class DynamicKeyboard
    {
        public static InlineKeyboardMarkup InlineKeyboard(string userChoise, DataContext context)
        {
            var products = context.Products.Where(p => p.Type == userChoise);

            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
            foreach (var product in products)
            {
                buttons.Add(new[] {
                    InlineKeyboardButton.WithCallbackData(Emoji.Mushroom + product.Name, product.Name)
                });
            }
            return new InlineKeyboardMarkup(buttons);
        }

        public static ReplyKeyboardMarkup ProductTypesKeyboard(List<Product> products)
        {
            List<KeyboardButton[]> buttons = new List<KeyboardButton[]>();
            List<KeyboardButton> tmp = new List<KeyboardButton>();
            foreach (var product in products)
            {
                if (tmp.Count < 2)
                {
                    tmp.Add(new KeyboardButton(product.Name));
                }
                else
                {
                    buttons.Add(tmp.ToArray());
                    tmp.Clear();
                    tmp.Add(new KeyboardButton(product.Name));
                }
            }
            if (tmp.Count != 0)
                buttons.Add(tmp.ToArray());
            buttons.Add(new KeyboardButton[] { ButtonText.BackToMain, ButtonText.Back });

            return new ReplyKeyboardMarkup(buttons) { ResizeKeyboard = true };
        }
    }
}
