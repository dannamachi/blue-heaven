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
        private static Dictionary<CharacterCode, string> _nameDict = new Dictionary<CharacterCode, string>
        {
            { CharacterCode.Player,"Player" },
            { CharacterCode.Mochi,"Mochi Tester" },
            { CharacterCode.KingCrab,"Crab King" }
        };

        public static string GetName(CharacterCode code)
        {
            if (_nameDict.ContainsKey(code)) return _nameDict[code];
            else return "A stranger";
        }
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
