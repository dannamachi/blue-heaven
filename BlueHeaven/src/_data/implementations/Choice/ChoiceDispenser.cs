using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data.Choice
{
    /// <summary>
    /// Data object to contain choices
    /// </summary>
    public class ChoiceDispenser : IHaveChoice
    {
        private ChoiceDispenserCode _code;
        private List<IChoice> _choices;
        private IChoice _chosen;
        public ChoiceDispenser(ChoiceDispenserCode code, List<IChoice> choices)
        {
            _code = code;
            _choices = choices;
            _chosen = null;
        }

        /// <summary>
        /// Set chosen choice by index
        /// </summary>
        /// <param name="num"></param>
        public void SetChoice(int num)
        {
            if (num >= 0 && num < _choices.Count)
                _chosen = _choices[num];
        }

        /// <summary>
        /// Get list of choices
        /// </summary>
        public List<IChoice> Choices { get => _choices; }

        /// <summary>
        /// Get chosen choice
        /// </summary>
        public IChoice Chosen { get => _chosen; }

        /// <summary>
        /// Get bool if identified by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool IsCalled(ChoiceDispenserCode code)
        {
            return code == _code;
        }
    }
}
