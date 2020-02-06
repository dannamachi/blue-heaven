using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Data.Choice;
namespace BlueHeaven.src.Enums
{
    // enum: choice source
    public enum ChoiceDispenserCode
    {
        SayHelloOrNah
    }
    public static class DecisionBuilder
    {
        private static Dictionary<ChoiceDispenserCode, IHaveChoice> _decisionDict = new Dictionary<ChoiceDispenserCode, IHaveChoice>();
        public static IHaveChoice GetChoiceDispenser(ChoiceDispenserCode code)
        {
            if (_decisionDict.ContainsKey(code)) return _decisionDict[code];
            return null;
        }
        public static void DefineDecision()
        {
            _decisionDict[ChoiceDispenserCode.SayHelloOrNah] = new ChoiceDispenser(
                new List<IChoice> {
                new Choice(
                    "Say Hello",
                    new List<IAffectCharacter>{
                        new ChoiceEffect(
                            "Mochi",SentimentEffect.Up,"Player"
                        )
                    }
                ),
                new Choice(
                    "Ignore",
                    new List<IAffectCharacter>{

                    }
                )
                }
            );
        }
    }
}