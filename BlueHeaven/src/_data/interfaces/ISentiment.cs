namespace BlueHeaven.src.Data
{
    public enum SentimentStatus
    {
        SwornEnemy = -40,
        BitterEnemy = -20,
        Enemy = -10,
        Stranger = 0,
        Acquaintance = 10,
        Friend = 25,
        GoodFriend = 45,
        TrustedFriend = 70,
        CloseFriend = 80,
        Lover = 100
    }

    public interface ISentiment
    {
        bool IsOfStatus(int status);
        bool IsOfStatus(SentimentStatus status);
        bool IsBelowStatus(int status);
        bool IsBelowStatus(SentimentStatus status);
        void IncreaseBy(int num);
        bool IsRomantic { get; set; }
        // DEBUG
        int Status { get; }
    }
}