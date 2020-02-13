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
        SayHelloOrNah,
        WarCry
    }

    // Romance = 0,
    // Up = 5,
    // UpTwice = 10,
    // Down = -5,
    // DownTwice = -10,
    // DownAll = -60

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
                            CharacterCode.Mochi,SentimentEffect.Up,CharacterCode.Player
                        )
                    }),
                new Choice(
                    "Ignore",
                    new List<IAffectCharacter>{
                        new ChoiceEffect(
                            CharacterCode.KingCrab,SentimentEffect.Up,CharacterCode.Player
                        )
                    })
                }),
            #endregion
            #region War Cry
            new ChoiceDispenser(
                ChoiceDispenserCode.WarCry,
                new List<IChoice> {
                new Choice(
                    "Flare up",
                    new List<IAffectCharacter>{
                        new ChoiceEffect(
                            CharacterCode.Mochi,SentimentEffect.Up,CharacterCode.Player
                        )
                    }),
                new Choice(
                    "Glare back coolly",
                    new List<IAffectCharacter>{
                        new ChoiceEffect(
                            CharacterCode.KingCrab,SentimentEffect.UpTwice,CharacterCode.Player
                        )
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