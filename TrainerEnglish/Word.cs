namespace TrainerEnglish
{
    public class Word
    {
        public Word(string word, string translation)
        {
            this.word = word;
            this.translation = translation;
        }
        public string word { get; private set; }
        public string translation { get; private set; }
    }
}
