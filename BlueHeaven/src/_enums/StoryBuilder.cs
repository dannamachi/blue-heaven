using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Data.Story;
using BlueHeaven.src.Data.Choice;
namespace BlueHeaven.src.Enums
{
    /// <summary>
    /// Code for conversation object
    /// </summary>
    public enum ConversationCode
    {
        WelcomeToBlueHeaven,
        AnotherGreeting
    }

    /// <summary>
    /// Container of conversations
    /// </summary>
    public static class StoryBuilder
    {
        /// <summary>
        /// Get a conversation object from code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns> 
        public static IConversation GetConversation(ConversationCode code)
        {
            foreach (IConversation convo in _storyList)
            {
                if (convo.IsCalled(code)) return convo;
            }
            return null;
        }

        /// <summary>
        /// Get list of conversation codes based on key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<ConversationCode> GetPackage(string key)
        {
            // return different packages by different keys
            // for now return all test convos
            return new List<ConversationCode> { ConversationCode.AnotherGreeting, ConversationCode.WelcomeToBlueHeaven };
        }
        
        /// <summary>
        /// Get list of conversation objects from list of codes
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public static List<IConversation> GetConversations(List<ConversationCode> codes)
        {
            List<IConversation> conversations = new List<IConversation>();
            foreach (ConversationCode code in codes)
            {
                if (GetConversation(code) != null)
                    conversations.Add(GetConversation(code));
            }
            return conversations;
        }

        private static List<IConversation> _storyList = new List<IConversation>
        {
            #region Welcome to Blue Heaven
            new Conversation(
                ConversationCode.WelcomeToBlueHeaven,
                new List<IConversationLine> {
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "Hello!",
                            "Hope you are ready for some great fun!",
                            "This will be the greatest game ever!!"
                        },
                        "Hello from the tester"),
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "Omg...",
                            "Aren't you a poor little cutie?",
                            "So bored that you'd resort to playing this xDDD",
                            "So the game is called Blue Heaven...let's begin!"
                        })
                }),
            #endregion
            #region Another Greeting
            new Conversation(
                ConversationCode.AnotherGreeting,
                new List<IConversationLine> {
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "And I am back!",
                            "Hi Hi Hi hi hi hi!!!",
                            "How are you feeling?",
                            "Isn't it a great day today???",
                            "I'm trying my best; are you annoyed just yet?"
                        },
                        "Say Hello once more"
                    )
                },
                new List<IProvideCondition>
                {
                    new ConversationCondition(ConversationCode.WelcomeToBlueHeaven)
                },
                new List<IProvideCondition>
                {
                })
            #endregion
            // Next conversation?
        };
    }
}