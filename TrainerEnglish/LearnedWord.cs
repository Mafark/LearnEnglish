namespace TrainerEnglish
{
    public class LearnedWord
    {
        int count = 1;
        bool show = true;
        public LearnedWord(string word, string translation)
        {
            Word = word;
            Translation = translation;
        }
        public void AddView()
        {
            if (count == 2)
            {
                count++;
                show = false;
            }
            else if (count < 3)
            {
                count++;
            }
            else show = false;
        }
        public int Count => count;
        public bool Show => show;
        public string Word { get; private set; }
        public string Translation { get; private set; }
    }
}
