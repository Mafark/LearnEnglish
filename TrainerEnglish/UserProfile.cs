using System.Collections.Generic;
using System.Linq;

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

        public LearnedWord[] learnedWords { get { return _learnedWord.ToArray(); } }

        public void AddWord(Word newWord)
        {
            var newLearnedWord = _learnedWord
                .FirstOrDefault(learnedWord => learnedWord.Word == newWord.word);

            if (newLearnedWord == null)
            {
                _learnedWord.Add(new LearnedWord(newWord.word, newWord.translation));
            }
            else
            {
                newLearnedWord.AddView();
            }
        }
    }
}
