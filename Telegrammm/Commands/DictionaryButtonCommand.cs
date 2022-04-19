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
        private Dictionary<long, Conversation> chats;

        public DictionaryButtonCommand(ITelegramBotClient botClient)
        {
            this.botClient = botClient;

            CommandText = "/dictionary";

            chats = new Dictionary<long, Conversation>();
        }

        public void AddCallBack(Conversation chat)
        {
            chats[chat.GetId()] = chat;

            this.botClient.OnCallbackQuery -= Bot_Callback;
            this.botClient.OnCallbackQuery += Bot_Callback;
        }

        private async void Bot_Callback(object sender, CallbackQueryEventArgs e)
        {
            var chatId = e.CallbackQuery.Message.Chat.Id;

            if (!chats.ContainsKey(chatId))
                return;

            var chat = chats[chatId];

            string msg = "";

            switch (e.CallbackQuery.Data)
            {
                case "Русские слова":
                    msg = string.Join("\n", chat.dictionary.Values.Select(w => GetRussian(w))); 
                    break;
                case "Английские слова":
                default:
                    msg = string.Join("\n", chat.dictionary.Values.Select(w => GetEnglish(w)));
                    break;
            }

            if (string.IsNullOrEmpty(msg))
                msg = "Словарь пустой";

            await botClient.SendTextMessageAsync(chatId, msg);
            await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
        }

        private string GetRussian(Word w)
            => $"{w.Russian}: {w.English} ({w.Theme})";
        private string GetEnglish(Word w)
            => $"{w.English}: {w.Russian} ({w.Theme})";

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
