using System.Collections.Generic;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data
{
    // abstract: contains data about content of a conversation/scene
    public interface IConversation
    {
        ConversationCode ConCode { get; }
        string Name { get; }
        bool CanBeRead(IGameState gameState);
        bool IsCalled(string name);
        bool IsCalled(ConversationCode code);
        bool IsFinished { get; }
        IConversationLine GetConversationLine(IGameState gameState);
        // may contain choice or nah
        bool HaveChoice { get; }
        // depending on IGameState, choice may be chosen automatically
        bool CanChoose(IGameState gameState);
        // get to choose only if HaveChoice
        IHaveChoice GetChoiceDispenser { get; }
        void Advance();
        void SetCondition(List<IProvideCondition> toGet, List<IProvideCondition> toChoose);
        MilestoneCode MileCode { get; }
    }
}