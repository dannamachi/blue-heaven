namespace BlueHeaven.src.Data
{
    // data: feelings of ICharacter
    public class Sentiment : ISentiment
    {
        private int _status;
        public Sentiment(int initial, bool initialRomance = false)
        {
            _status = initial;
            IsRomantic = initialRomance;
        }
        public bool IsOfStatus(SentimentStatus status)
        {
            if (IsPositive)
            {
                return _status >= (int)status;
            }
            else
            {
                return _status <= (int)status;
            }
        }
        public void IncreaseBy(int num)
        {
            _status += num;
            int upperlimit = 90;
            if (IsRomantic) upperlimit += 30;
            if (_status > upperlimit) _status = upperlimit;
        }
        public void DecreaseBy(int num)
        {
            _status -= num;
            int lowerlimit = -25;
            if (IsRomantic) lowerlimit -= 30;
            if (_status < lowerlimit) _status = lowerlimit;
        }
        public bool IsRomantic { get; set; }
        private bool IsPositive { get => _status >= 0; }
    }
}