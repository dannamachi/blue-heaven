namespace BlueHeaven.src.Data
{
    // abstract: condition for IConversation to occur
    public interface IProvideCondition
    {
        bool IsFulfilledBy(IGameState gameState);
    }
}