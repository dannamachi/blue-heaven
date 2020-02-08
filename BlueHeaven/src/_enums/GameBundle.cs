using System.Collections.Generic;
namespace BlueHeaven.src.Enums
{
    /// <summary>
    /// Link conversation to name (string) and choices (choice dispenser)
    /// </summary>
    public class GameBundle
    {
        private static Dictionary<ConversationCode, ChoiceDispenserCode> _cDict = new Dictionary<ConversationCode, ChoiceDispenserCode>
        {
            { ConversationCode.WelcomeToBlueHeaven, ChoiceDispenserCode.SayHelloOrNah },
            { ConversationCode.AnotherGreeting, ChoiceDispenserCode.None }
        };

        private static Dictionary<ConversationCode, string> _nameDict = new Dictionary<ConversationCode, string>
        {
            { ConversationCode.WelcomeToBlueHeaven, "Welcome to Blue Heaven" },
            { ConversationCode.AnotherGreeting, "Another Greeting" }
        };

        /// <summary>
        /// Get choice dispenser linked with convo
        /// </summary>
        /// <param name="convo"></param>
        /// <returns></returns>
        public static ChoiceDispenserCode GetChoices(ConversationCode convo)
        {
            if (_cDict.ContainsKey(convo)) return _cDict[convo];
            return ChoiceDispenserCode.None;
        }

        /// <summary>
        /// Get name (string) linked with convo
        /// </summary>
        /// <param name="convo"></param>
        /// <returns></returns>
        public static string GetName(ConversationCode convo)
        {
            if (_nameDict.ContainsKey(convo)) return _nameDict[convo];
            else return "Just another conversation";
        }
    }    
}
