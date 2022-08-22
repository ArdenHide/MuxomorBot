using Telegram.Bot.Types.ReplyMarkups;

namespace MuxomorBot.Keyboards
{
    public static class MainKeyboard
    {
        public static ReplyKeyboardMarkup ReplyKeyboard()
        {
            return new ReplyKeyboardMarkup(
            new[]
            {
                new KeyboardButton[] { ButtonText.GetCategories, ButtonText.Guide },
                new KeyboardButton[] { ButtonText.SendingAbroad, ButtonText.QualityCertificate },
                new KeyboardButton[] { ButtonText.ShippingAndPayment, ButtonText.Timetable },
            }){ ResizeKeyboard = true };
        }
    }
}
