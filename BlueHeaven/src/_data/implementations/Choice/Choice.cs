using System.Collections.Generic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Data.Choice
{
    // data: user choice
    public class Choice : IChoice
    {
        private string _name;
        private List<IAffectCharacter> _effects;
        public Choice(string name, List<IAffectCharacter> effects)
        {
            _name = name;
            _effects = effects;
        }
        public string Name { get => _name; }
        public bool IsCalled(string name)
        {
            return name.Trim() == _name.Trim();
        }
        public void IsChosen(IGameState gameState)
        {
            foreach (IAffectCharacter effect in _effects)
            {
                effect.GiveEffect(gameState.GetCharacter(effect.AffectWho));
            }
        }
    }
}