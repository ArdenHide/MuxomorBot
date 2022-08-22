using Microsoft.Extensions.DependencyInjection;
using MuxomorBot.Commands;
using MuxomorBot.Data;
using MuxomorBot.Keyboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MuxomorBot.Services
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly List<BaseCommand> _commands;
        private BaseCommand _lastCommand;
        private DataContext _context;

        public CommandExecutor(IServiceProvider serviceProvider, DataContext context)
        {
            _commands = serviceProvider.GetServices<BaseCommand>().ToList();
            _context = context;
        }

        public async Task Execute(Update update)
        {
            if (update?.Message?.Chat == null && update?.CallbackQuery == null)
                return;

            if (update.Type == UpdateType.Message)
            {
                switch (update.Message?.Text)
                {
                    case ButtonText.BackToMain:
                        await ExecuteCommand(CommandNames.BackToMain, update);
                        return;
                    case ButtonText.GetCategories:
                        await ExecuteCommand(CommandNames.GetCategories, update);
                        return; 
                }

                var categories = _context.Categories.ToList();
                foreach (var category in categories)
                {
                    if (category.DisplayName == update.Message?.Text)
                    {
                        await ExecuteCommand(CommandNames.GetProductTypes, update);
                        return;
                    }
                }
            }

            
            if (update.Type == UpdateType.CallbackQuery)
            {
                string callbackQuery = update.CallbackQuery.Data;
                //if (callbackQuery.Contains(ProductType.WholeCapsOpened.ToString()) &&
                //    callbackQuery.Contains(ProductType.WholeCapsUnopened.ToString()) &&
                //    callbackQuery.Contains(ProductType.WholeCapsPanther.ToString()) &&
                //    callbackQuery.Contains(ProductType.WholeCapsVip.ToString()))
                //{
                //    await ExecuteCommand(CommandNames.WholeCapsChoiseCategory, update);
                //    return;
                //}


                //if (callbackQuery.Contains(ProductType.WholeCapsOpened.ToString()) &&
                //    callbackQuery.Contains(ProductType.WholeCapsUnopened.ToString()) &&
                //    callbackQuery.Contains(ProductType.WholeCapsPanther.ToString()) &&
                //    callbackQuery.Contains(ProductType.WholeCapsVip.ToString()))
                //{
                //    await ExecuteCommand(CommandNames.WholeCapsChoiseCategory, update);
                //    return;
                //}
            }

            if (update.Message != null && update.Message.Text.Contains(CommandNames.Start))
            {
                await ExecuteCommand(CommandNames.Start, update);
                return;
            }

            switch (_lastCommand?.Name)
            {
                case CommandNames.BackToMain:
                {
                    await ExecuteCommand(CommandNames.BackToMain, update);
                    break;
                }
                case CommandNames.GetCategories:
                {
                    await ExecuteCommand(CommandNames.BackToMain, update);
                    break;
                }
                case null:
                {
                    await ExecuteCommand(CommandNames.BackToMain, update);
                    break;
                }
            }
        }

        private async Task ExecuteCommand(string commandName, Update update)
        {
            _lastCommand = _commands.First(x => x.Name == commandName);
            await _lastCommand.ExecuteAsync(update);
        }
    }
}
