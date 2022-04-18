using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot
{
    public class SayHiCommand : AbstractCommand, IChatTextCommand
    {
        public SayHiCommand()
        {
            CommandText = "Привет";
           

        }

        public string ReturnText()
        {
            return "привет";
        }

    }
}
