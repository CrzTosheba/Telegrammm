using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.EnglishTrainer.Model;

namespace TelegramBot.Commands
{
    public class DictionaryButtonCommand : AbstractCommand, IKeyBoardCommand
    {
        ITelegramBotClient botClient;
        
            
           
        public DictionaryButtonCommand(ITelegramBotClient botClient)
        {
            this.botClient = botClient;

            CommandText = "/dictionary";
        }

        public void AddCallBack(Conversation chat)
        {
            this.botClient.OnCallbackQuery -= Bot_Callback;
            this.botClient.OnCallbackQuery += Bot_Callback;
        }

        private async void Bot_Callback(object sender, CallbackQueryEventArgs e)
        {
            var text = "";

            switch (e.CallbackQuery.Data)
            {
                case "Русские слова":
                    text = @""; 
                    break;
                case "Английские слова":
                    text = @"";
                    break;
                default:
                    break;
            }

            await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, text);
            await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
        }

        public InlineKeyboardMarkup ReturnKeyBoard()
        {
            var buttonList = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton
                {
                    Text = "Русский",
                    CallbackData = "Русские слова"
                },

                new InlineKeyboardButton
                {
                    Text = "Английский",
                    CallbackData = "Английские слова"
                }
            };

            var keyboard = new InlineKeyboardMarkup(buttonList);

            return keyboard;
        }

        public string InformationalMessage()
        {
            return "Выберите язык";
        }
    }
}
