using System;

namespace TrainerEnglish
{
    public class EnglishTrainer : IEnglishTrainer
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private Word[] _listOFWords;
        private IUserProfile _userProfile;

        static Random rand = new Random();
        Word originalWord;

        public EnglishTrainer(IUserProfileRepository userProfileRepository, IWordsRepository wordsRepository, int userId)
        {
            _userProfileRepository = userProfileRepository;
            _listOFWords = wordsRepository.GetAllWords();
            SessionStart(userId);
        }

        public void SessionStart(int UserId)
        {
            _userProfile = _userProfileRepository.GetUserProfile(UserId);
        }

        public string[] GetListWords(int length)
        {
            var listWordsGetter = new ListWordsGetter(length, _userProfile, _listOFWords);
            originalWord = listWordsGetter.OriginalWord;
            return listWordsGetter.GetListWords();
        }

        public bool SaveReulst(string selectedWord)
        {
            if (originalWord.translation == selectedWord)
            {
                _userProfile.AddWord(originalWord);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
