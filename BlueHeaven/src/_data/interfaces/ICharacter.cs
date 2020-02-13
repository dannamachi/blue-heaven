using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data
{
    // abstract: contains data to pick corresponding line for each conversation <<< FIX >>>
    public interface ICharacter
    {
        bool IsCalled(CharacterCode charCode);
        int IsOfPersonality { get; set; }
        ISentiment SentimentTowards(CharacterCode charCode);
        bool HasSentimentTowards(CharacterCode charCode);
        bool IsBroken { get; }
        void TogglePersonality(int num);
        string Name { get; }
    }
}