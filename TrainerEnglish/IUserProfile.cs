namespace TrainerEnglish
{
    public interface IUserProfile
    {
        int Id { get; }
        string Nickname { get; }
        LearnedWord[] learnedWords { get; }
        void AddWord(Word newWord);
    }
}
