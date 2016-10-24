using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainerEnglish;
using TrainerEnglish.Users;

namespace EnglishTrainerTests
{
    [TestClass]
    public class UserProfileTests
    {
        [TestMethod]
        public void AddWord_AddedWord()
        {
            var user = new UserProfile(0, "nickname", null);
            user.AddWord(new Word("Слово", "Перевод"));
            string expectedWord = "Слово";
            string expectedTranslation = "Перевод";
            Assert.IsTrue(expectedWord == user.learnedWords[0].Word
                && expectedTranslation == user.learnedWords[0].Translation);
        }

        [TestMethod]
        public void AddExistingWord_RightCountOfViews()
        {
            var user = new UserProfile(0, "nickname", null);
            user.AddWord(new Word("Слово", "Перевод"));
            user.AddWord(new Word("Слово", "Перевод"));
            var expectedCount = 2;
            Assert.AreEqual(expectedCount, user.learnedWords[0].Count);
        }

        [TestMethod]
        public void AddExistingWordMoreThanMaxViews_ShouldNotBeShow()
        {
            var user = new UserProfile(0, "nickname", null);
            user.AddWord(new Word("Слово", "Перевод"));
            user.AddWord(new Word("Слово", "Перевод"));
            user.AddWord(new Word("Слово", "Перевод"));
            var expectedShow = false;
            Assert.AreEqual(expectedShow, user.learnedWords[0].Show);
        }
    }
}
