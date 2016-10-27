using System;
using System.Linq;

namespace TrainerEnglish
{
    public class ListWordsGetter
    {
        int length;
        IUserProfile _userProfile;
        Word[] _listOFWords;

        Word originalWord;
        public Word OriginalWord { get { return originalWord; } }
        static Random rand = new Random();

        public ListWordsGetter(int length, IUserProfile userProfile, Word[] listOFWords)
        {
            this.length = length;
            _userProfile = userProfile;
            _listOFWords = listOFWords;
            originalWord = _listOFWords[rand.Next(0, _listOFWords.Length)];
        }

        public string[] GetListWords()
        {
            string[] generatedWords = new string[length + 1];

            generatedWords[0] = originalWord.word;
            generatedWords[rand.Next(1, length + 1)] = originalWord.translation;

            int[] indexes = GetIndexesOfTranslation(originalWord);

            var i = -1;
            return generatedWords.ToList().Select(word => {
                if (word == null) word = _listOFWords[indexes[i]].translation;
                i++;
                return word;
            }).ToArray();
        }

        public int[] GetIndexesOfTranslation(Word OriginalWord)
        {
            int[] indexes = new int[length];
            int Index;

            return indexes.
                Select(item => {
                Index = rand.Next(0, _listOFWords.Length);
                _userProfile.learnedWords.ToList()
                    .ForEach(learnedWord => {
                        while (learnedWord.Word == _listOFWords[Index].word
                                                || !learnedWord.Show)
                        {
                            Index = rand.Next(0, _listOFWords.Length);
                        };
                    });
                    return Index;
            }).ToArray();
        }
    }
}
