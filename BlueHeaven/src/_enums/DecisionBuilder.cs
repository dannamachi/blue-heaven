using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Data.Choice;
namespace BlueHeaven.src.Enums
{
    /// <summary>
    /// Code for decision (choice dispenser object)
    /// </summary>
    public enum ChoiceDispenserCode
    {
        None,
        SayHelloOrNah
    }

    /// <summary>
    /// Container of choices
    /// </summary>
    public static class DecisionBuilder
    {
        private static List<IHaveChoice> _decisionList = new List<IHaveChoice>
        {
            #region Say Hello Or Nah
            new ChoiceDispenser(
                ChoiceDispenserCode.SayHelloOrNah,
                new List<IChoice> {
                new Choice(
                    "Say Hello",
                    new List<IAffectCharacter>{
                        new ChoiceEffect(
                            "Mochi",SentimentEffect.Up,"Player"
                        )
                    }),
                new Choice(
                    "Ignore",
                    new List<IAffectCharacter>{

                    })
                })
            #endregion
        };

        /// <summary>
        /// Get choice dispenser via code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static IHaveChoice GetChoiceDispenser(ChoiceDispenserCode code)
        {
            foreach (IHaveChoice decision in _decisionList)
            {
                if (decision.IsCalled(code)) return decision;
            }
            return null;
        }
    }
}