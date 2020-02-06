using System.Collections.Generic; 
namespace BlueHeaven.src.Data
{
    // abstract: contains speaker and content of speech
    public interface IConversationLine
    {
        bool IsCalled(string name);
        string Speaker { get; }
        string Sentence { get; }
    }
}