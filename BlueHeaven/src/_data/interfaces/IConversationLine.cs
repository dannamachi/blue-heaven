using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data
{
    // abstract: contains speaker and content of speech
    public interface IConversationLine
    {
        BackgroundCode Background { get; }
        StoryGraphicCode GraphicCode { get; }
        string Speaker { get; }
        string Sentence { get; }
        bool IsFinished { get; }
    }
}