namespace BlueHeaven.src.Data
{
    // abstract: contains data to pick corresponding line for each conversation <<< FIX >>>
    public interface ICharacter
    {
        bool IsCalled(string name);
        int IsOfPersonality { get; set; }
        ISentiment SentimentTowards(string name);
        bool HasSentimentTowards(string name);
        bool IsBroken { get; }
        void TogglePersonality(int num);
    }
}