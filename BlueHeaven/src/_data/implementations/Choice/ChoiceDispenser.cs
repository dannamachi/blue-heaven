using System.Collections.Generic;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Data.Choice
{
    // data: container for IChoice
    public class ChoiceDispenser : IHaveChoice
    {
        private List<IChoice> _choices;
        private IChoice _chosen;
        public ChoiceDispenser(List<IChoice> choices)
        {
            _choices = choices;
            _chosen = null;
        }
        public void SetChoice(int num)
        {
            if (num >= 0 && num < _choices.Count)
                _chosen = _choices[num];
        }
        public List<IChoice> Choices { get => _choices; }
        public IChoice Chosen { get => _chosen; }
    }
}
