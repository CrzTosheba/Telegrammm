using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.EnglishTrainer.Model;

namespace Telegrammm.Repository
{
    internal class WordRepo : IRepository<Word>
    {
        private Dictionary<string, Word> _items = new Dictionary<string, Word>();

        public void Add(Word item)
            => _items[item.English] = item;

        public IEnumerable<Word> All()
            => _items.Values;

        public void Delete(Word item)
            => _items.Remove(item.English);
    }
}
