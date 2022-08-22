using MuxomorBot.Data.Entities;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace MuxomorBot.Keyboards
{
    public static class CategoriesKeyboard
    {
        public static ReplyKeyboardMarkup GetDynamicReplyKeyboard(List<Category> categories)
        {
            List<KeyboardButton[]> buttons = new List<KeyboardButton[]>();
            List<KeyboardButton> tmp = new List<KeyboardButton>();
            foreach (var category in categories)
            {
                if (tmp.Count < 2)
                {
                    tmp.Add(new KeyboardButton(category.DisplayName));
                }
                else
                {
                    buttons.Add(tmp.ToArray());
                    tmp.Clear();
                    tmp.Add(new KeyboardButton(category.DisplayName));
                }
            }
            if (tmp.Count != 0)
                buttons.Add(tmp.ToArray());
            buttons.Add(new KeyboardButton[] { ButtonText.BackToMain, ButtonText.Back });

            return new ReplyKeyboardMarkup(buttons) { ResizeKeyboard = true };
        }
    }
}
