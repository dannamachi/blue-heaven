using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Data.Choice;

namespace BlueHeaven.src.Enums
{
    public enum CharacterCode
    {
        Player,
        Mochi,
        KingCrab
    }

    /// <summary>
    /// Builder for characters
    /// </summary>
    public class CharacterBuilder
    {
        public static List<ICharacter> GetCharacters(List<CharacterCode> charCodes)
        {
            List<ICharacter> charList = new List<ICharacter>();
            foreach (CharacterCode code in charCodes)
            {
                if (_charList.ContainsKey(code)) charList.Add(_charList[code]);
            }
            return charList;
        }

        private static Dictionary<CharacterCode, ICharacter> _charList = new Dictionary<CharacterCode, ICharacter>
        {
            #region Mochi
            {
                CharacterCode.Mochi,
                new Character(CharacterCode.Mochi,
                new Dictionary<CharacterCode, ISentiment>
                {
                    { CharacterCode.Player, new Sentiment(20) },
                    { CharacterCode.KingCrab, new Sentiment(-10) }
                },
                Personality.Mochi)
            },
            #endregion
            #region KingCrab
            {
                CharacterCode.KingCrab,
                new Character(CharacterCode.KingCrab,
                new Dictionary<CharacterCode, ISentiment>
                {
                    { CharacterCode.Player, new Sentiment(5) },
                    { CharacterCode.Mochi, new Sentiment(-20) }
                },
                Personality.KingCrab)
            },
            #endregion
            #region Player
            {
                CharacterCode.Player,
                new Character(CharacterCode.Player,
                new Dictionary<CharacterCode, ISentiment>
                {
                    { CharacterCode.Mochi, new Sentiment(5) },
                    { CharacterCode.KingCrab, new Sentiment(5) }
                })
            }
            #endregion
        };
    }
}
