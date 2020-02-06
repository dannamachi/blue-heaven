using System.Collections.Generic;
using BlueHeaven.src.Data;
using BlueHeaven.src.Data.Story;
namespace BlueHeaven.src.Enums
{
    // enum: conversation source
    public enum ConversationCode
    {
        WelcomeToBlueHeaven,
        AnotherGreeting
    }

    public static class StoryBuilder
    {
        private static Dictionary<ConversationCode, IConversation> _storyDict = new Dictionary<ConversationCode, IConversation>();
        public static IConversation GetConversation(ConversationCode code)
        {
            if (_storyDict.ContainsKey(code)) return _storyDict[code];
            return null;
        }
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
        public static void DefineStory()
        {

            _storyDict[ConversationCode.WelcomeToBlueHeaven] = new Conversation(
                "Welcome to Blue Heaven",
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
                        "Hello!",
                        "Hope you are ready for some great fun!",
                        "This will be the greatest game ever!!"
                    })
                });

            _storyDict[ConversationCode.AnotherGreeting] = new Conversation(
                "Another Greeting",
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
                });
        }
    }
}