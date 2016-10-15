using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainerEnglish;

namespace EnglishTrainerTests
{
    [TestClass]
    public class EnglishTrainerTests
    {
        [TestMethod]
        public void GetListWords_GetNotNullArrayWith4Elements()
        {
            string userRepository = "[{\"Id\":0,\"Nickname\":\"nickname0\",\"words\":[{\"show\":true,\"Count\":0,\"word\":\"Слово0\",\"translation\":\"Перевод0\"}]}]";
            string wordsRepository = "[{\"show\":true,\"Count\":0,\"word\":\"Слово0\",\"translation\":\"Перевод0\"},{\"show\":true,\"Count\":0,\"word\":\"Слово1\",\"translation\":\"Перевод1\"},{\"show\":true,\"Count\":0,\"word\":\"Слово2\",\"translation\":\"Перевод2\"},{\"show\":true,\"Count\":0,\"word\":\"Слово3\",\"translation\":\"Перевод3\"},{\"show\":true,\"Count\":0,\"word\":\"Слово4\",\"translation\":\"Перевод4\"},{\"show\":true,\"Count\":0,\"word\":\"Слово5\",\"translation\":\"Перевод5\"},{\"show\":true,\"Count\":0,\"word\":\"Слово6\",\"translation\":\"Перевод6\"}]";
            var users = new UserProfileRepositiryStub(userRepository);
            var words = new WordsRepositoryStub(wordsRepository);
            var englishTrainer = new EnglishTrainer(users, words, 0);
            bool arrayIsFilled = true;

            string[] listWords = englishTrainer.GetListWords(3);

            for(var i = 0; i < 3; i++)
            {
                if (listWords[i] == null) arrayIsFilled = false;
            }
            Assert.IsTrue(arrayIsFilled && (listWords.Length == 4));
        }
    }


}
