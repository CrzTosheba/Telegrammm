using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace TelegramBot.Commands
{
    public class DeleteWordCommand : ChatTextCommandOption, IChatTextCommandWithAction
    {
        public DeleteWordCommand()
        {
            CommandText = "/deleteword";
        }


        public bool DoAction(Conversation chat)
        {
            try
            {
                var message = chat.GetLastMessage();

                if (chat.IsTraningInProcess)
                    return false;

                if (!HasArgs(message))
                    return false;

                var text = ClearMessageFromCommand(message);

                if (!chat.dictionary.ContainsKey(text))
                    return false;

                chat.dictionary.Remove(text);
                return true;
            }
            catch (Exception ex)
            { 
                
            }
            

            return false; 
        }

        public string ReturnText()
        { 
            return "Слово успешно удалено!";
        }
    }
}
