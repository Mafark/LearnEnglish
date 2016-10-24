using System;

namespace TrainerEnglish
{
    public class ListWordsGetter
    {
        int length;
        IUserProfile _userProfile;
        Word[] _listOFWords;

        Word originalWord;
        public Word OriginalWord => originalWord;
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

            for(var i = 0; i < length; i ++)
            {
                if (generatedWords[i+1] == null)
                {
                    generatedWords[i + 1] = _listOFWords[indexes[i]].translation;
                }
            }

            return generatedWords;
        }

        public int[] GetIndexesOfTranslation(Word OriginalWord)
        {
            int[] indexes = new int[length];
            int Index;

            for (var j = 0; j < length; j++)
            {
                Index = rand.Next(0, _listOFWords.Length);

                for (var i = 0; i < _userProfile.learnedWords.Length; i++)
                {
                    while (_userProfile.learnedWords[i].Word == _listOFWords[Index].word
                        || !_userProfile.learnedWords[i].Show)
                    {
                        Index = rand.Next(0, _listOFWords.Length);
                    }
                }
                indexes[j] = Index;
            }

            return indexes;
        }
    }
}
