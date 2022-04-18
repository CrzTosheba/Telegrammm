using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot
{
    public class HelpCommand : AbstractCommand, IChatTextCommand
    { 
        

        public HelpCommand()
        {
            CommandText = "/help";


        }

        public string ReturnText()
        {
            var text = @"Команды для бота:
                          /dictionary - вывести словарь
                          /addword - добавить слово
                          /deleteword - удалить слово из словаря
                          /training - начать тренировку
                          /stop - остановить тренировку";
            return text;


        }

    }
}
