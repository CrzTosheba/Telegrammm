using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.EnglishTrainer.Model;

namespace Telegrammm.Repository
{
    //singeltone
    internal class RepoFactory
    {
        private static RepoFactory instance;

        public static RepoFactory Instance => instance ?? (instance = new RepoFactory());


        private RepoFactory() { }
        
        public IRepository<Word> Words { get; } = new WordRepo();
    }
}
