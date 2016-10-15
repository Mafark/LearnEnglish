using Newtonsoft.Json;
using TrainerEnglish;

namespace EnglishTrainerTests
{
    class WordsRepositoryStub : IWordsRepository
    {
        private readonly string _jsonDatabase;

        public WordsRepositoryStub(string json)
        {
            _jsonDatabase = json;
        }

        public Word[] GetAllWords()
        {
            var words = JsonConvert.DeserializeObject<Word[]>(_jsonDatabase);
            return words;
        }
    }
}
