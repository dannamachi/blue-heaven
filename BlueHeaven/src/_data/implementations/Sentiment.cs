namespace BlueHeaven.src.Data
{
    // data: feelings of ICharacter
    public class Sentiment : ISentiment
    {
        private int _status;
        // DEBUG
        public int Status { get => _status; }
        public Sentiment(int initial, bool initialRomance = false)
        {
            _status = initial;
            IsRomantic = initialRomance;
        }
        public bool IsBelowStatus(SentimentStatus status)
        {
            return _status < (int)status;
        }
        public bool IsBelowStatus(int status)
        {
            return _status < status;
        }
        public bool IsOfStatus(SentimentStatus status)
        {
            return _status >= (int)status;
        }
        public bool IsOfStatus(int status)
        {
            return _status >= status;
        }
        public void IncreaseBy(int num)
        {
            _status += num;

            int upperlimit = 90;
            if (IsRomantic) upperlimit += 30;
            if (_status > upperlimit) _status = upperlimit;

            int lowerlimit = -25;
            if (IsRomantic) lowerlimit -= 30;
            if (_status < lowerlimit) _status = lowerlimit;
        }
        public bool IsRomantic { get; set; }
        private bool IsPositive { get => _status >= 0; }
    }
}