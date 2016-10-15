using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainerEnglish;

namespace EnglishTrainerTests
{
    [TestClass]
    public class ListWordsGetterTests
    {
        [TestMethod]
        public void GetIndexesOfTranslation_CorrectIndexes()
        {
            string userRepository = "[{\"Id\":0,\"Nickname\":\"nickname0\",\"words\":[]}]";
            string wordsRepository = "[{\"show\":true,\"Count\":0,\"word\":\"Слово0\",\"translation\":\"Перевод0\"},{\"show\":true,\"Count\":0,\"word\":\"Слово1\",\"translation\":\"Перевод1\"},{\"show\":true,\"Count\":0,\"word\":\"Слово2\",\"translation\":\"Перевод2\"},{\"show\":true,\"Count\":0,\"word\":\"Слово3\",\"translation\":\"Перевод3\"},{\"show\":true,\"Count\":0,\"word\":\"Слово4\",\"translation\":\"Перевод4\"}]";
            var users = new UserProfileRepositiryStub(userRepository);
            var words = new WordsRepositoryStub(wordsRepository);
            var _userProfile = users.GetUserProfile(0);
            var _listOFWords = words.GetAllWords();
            var lengthOfListWords = 3;
            var wordsGetter = new ListWordsGetter(lengthOfListWords, _userProfile, _listOFWords);
            bool correct = true;

            int[] indexes = wordsGetter.GetIndexesOfTranslation(_listOFWords[0]);

            if(indexes.Length != lengthOfListWords) correct = false;
            for (var i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] > _listOFWords.Length || indexes[i] < 0) correct = false;
            }
            Assert.IsTrue(correct);
        }

        [TestMethod]
        public void GetListWords_CorrectListWords()
        {
            string userRepository = "[{\"Id\":0,\"Nickname\":\"nickname0\",\"words\":[{\"show\":true,\"Count\":0,\"word\":\"Слово0\",\"translation\":\"Перевод0\"},{\"show\":true,\"Count\":0,\"word\":\"Слово1\",\"translation\":\"Перевод1\"}]},{\"Id\":1,\"Nickname\":\"nickname1\",\"words\":[{\"show\":true,\"Count\":0,\"word\":\"Слово0\",\"translation\":\"Перевод0\"},{\"show\":true,\"Count\":0,\"word\":\"Слово1\",\"translation\":\"Перевод1\"}]}]";
            string wordsRepository = "[{\"show\":true,\"Count\":0,\"word\":\"Слово0\",\"translation\":\"Перевод0\"},{\"show\":true,\"Count\":0,\"word\":\"Слово1\",\"translation\":\"Перевод1\"},{\"show\":true,\"Count\":0,\"word\":\"Слово2\",\"translation\":\"Перевод2\"},{\"show\":true,\"Count\":0,\"word\":\"Слово3\",\"translation\":\"Перевод3\"},{\"show\":true,\"Count\":0,\"word\":\"Слово4\",\"translation\":\"Перевод4\"}]";
            var users = new UserProfileRepositiryStub(userRepository);
            var words = new WordsRepositoryStub(wordsRepository);
            var _userProfile = users.GetUserProfile(0);
            var _listOFWords = words.GetAllWords();
            var lengthOfListWords = 3;
            var listWordsGetter = new ListWordsGetter(lengthOfListWords, _userProfile, _listOFWords);
            bool correct = true;

            string[] listWords = listWordsGetter.GetListWords();

            for (var i = 0; i < 3; i++)
            {
                if (listWords[i] == null) correct = false;
            }
            Assert.IsTrue(correct && (listWords.Length == 4));
        }

    }
}
