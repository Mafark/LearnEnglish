using System.Collections.Generic;

namespace TrainerEnglish.Users
{
    public class UserProfile : IUserProfile
    {
        private List<LearnedWord> _learnedWord;

        public UserProfile(
            int id,
            string nickname,
            LearnedWord[] words)
        {
            Id = id;
            Nickname = nickname;
            _learnedWord = new List<LearnedWord>(words ?? new LearnedWord[0]);
        }

        public int Id { get; private set; }

        public string Nickname { get; private set; }

        public LearnedWord[] learnedWords
        {
            get
            {
                return _learnedWord.ToArray();
            }
        }

        public void AddWord(Word newWord)
        {

            bool found = false;
            for (var i = 0; i < _learnedWord.Count; i++)
            {
                if (_learnedWord[i].Word == newWord.word)
                {
                    if (_learnedWord[i].Count < 3)
                    {
                        _learnedWord[i].AddView();
                        found = true;
                    }
                }
            }
            if (!found)
            {
                _learnedWord.Add(new LearnedWord(newWord.word,newWord.translation));
            }
        }
    }
}
