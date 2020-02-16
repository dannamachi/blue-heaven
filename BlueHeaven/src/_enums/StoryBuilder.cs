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
        AnotherGreeting,
        WillYouBeTheTrueYou,
        YouHaveBeenGood,
        WhoAreYou
    }

    /// <summary>
    /// Code for graphic
    /// </summary>
    public enum StoryGraphicCode
    {
        Default,
        Mochi,
        KingCrab,
        MochiCrazy,
        CrazyKing
    }

    public enum BackgroundCode
    {
        Default
    }

    /// <summary>
    /// Code for story milestone (divergence)
    /// </summary>
    public enum MilestoneCode
    {
        None,
        WhoIsYourGuide
    }

    //    SwornEnemy = -40,
    //    BitterEnemy = -20,
    //    Enemy = -10,
    //    Stranger = 0,
    //    Acquaintance = 10,
    //    Friend = 25,
    //    GoodFriend = 45,
    //    TrustedFriend = 70,
    //    CloseFriend = 80,
    //    Lover = 100

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
                        StoryGraphicCode.Mochi),
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "Omg...",
                            "Aren't you a poor little cutie?",
                            "So bored that you'd resort to playing this xDDD",
                            "So the game is called Blue Heaven...let's begin!"
                        },
                        StoryGraphicCode.Mochi)
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
                            "I'm trying my best; are you annoyed just yet?",
                            "C'mon; act more alive!"
                        },
                        StoryGraphicCode.Mochi
                    )
                },
                new List<IProvideCondition>
                {
                    new ConversationCondition(ConversationCode.WelcomeToBlueHeaven)
                },
                new List<IProvideCondition>
                {
                }),
            #endregion
            #region Will you be the true you?
            new Conversation(
                ConversationCode.WillYouBeTheTrueYou,
                new List<IConversationLine> {
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "Well! I've always known you were with me.",
                            "After all, who wants to be like that stickler over there?",
                            "Since you've picked me this time,",
                            "let me be your guide!"
                        },
                        StoryGraphicCode.Mochi
                    ),
                    new ConversationLine(
                        "Crab King Tester 2",
                        new List<string> {
                            "Wait.",
                            "Are you sure you want that...thing to guide you?",
                            "Haven't you seen how unreliable she is?"
                        },
                        StoryGraphicCode.KingCrab
                    ),
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "Ah...! It's that annoying guy again.",
                            "Do you really wanna listen to his nonsensical rambling?"
                        },
                        StoryGraphicCode.Mochi
                    ),
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "...You don't!!"
                        },
                        StoryGraphicCode.MochiCrazy
                    ),
                    new ConversationLine(
                        "Crab King Tester 2",
                        new List<string> {
                            "So that is what you have chosen...",
                            "Fare thee well, anonymous traveller..."
                        },
                        StoryGraphicCode.KingCrab
                    ),
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "Let's go!!!"
                        },
                        StoryGraphicCode.Mochi
                    )
                },
                new List<IProvideCondition>
                {
                    new SentimentCondition(CharacterCode.Mochi,30,CharacterCode.Player),
                    new ConversationCondition(ConversationCode.AnotherGreeting)
                },
                new List<IProvideCondition>
                {
                },
                MilestoneCode.WhoIsYourGuide),
            #endregion
            #region You have been good
            new Conversation(
                ConversationCode.YouHaveBeenGood,
                new List<IConversationLine> {
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "...Is that it? This is your choice?",
                            "Why are you acting like this??"
                        },
                        StoryGraphicCode.Mochi
                    ),
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string>
                        {
                            "This isn't you! You aren't like..."
                        },
                        StoryGraphicCode.MochiCrazy
                    ),
                    new ConversationLine(
                        "Crab King Tester 2",
                        new List<string> {
                            "Silent."
                        },
                        StoryGraphicCode.KingCrab
                    ),
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "...tha...zzz..."
                        },
                        StoryGraphicCode.MochiCrazy
                    ),
                    new ConversationLine(
                        "Crab King Tester 2",
                        new List<string> {
                            "And that annoying fly has finally stopped yapping.",
                            "Doesn't it make you feel better?",
                            "Why act in such a manner when you can be perfect?",
                            "Listen to me, stay calm and composed.",
                            "That is how I will take you through this game."
                        },
                        StoryGraphicCode.KingCrab
                    ),
                    new ConversationLine(
                        "Crab King Tester 2",
                        new List<string> {
                            "With perfection."
                        },
                        StoryGraphicCode.CrazyKing
                    )
                },
                new List<IProvideCondition>
                {
                    new SentimentCondition(CharacterCode.KingCrab,20,CharacterCode.Player),
                    new ConversationCondition(ConversationCode.AnotherGreeting)
                },
                new List<IProvideCondition>
                {
                },
                MilestoneCode.WhoIsYourGuide),
            #endregion
            #region Who are you?
            new Conversation(
                ConversationCode.WhoAreYou,
                new List<IConversationLine> {
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "...",
                            "So this..."
                        },
                        StoryGraphicCode.Mochi
                    ),
                    new ConversationLine(
                        "Crab King Tester 2",
                        new List<string> {
                            "...is interesting."
                        },
                        StoryGraphicCode.KingCrab
                    ),
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "Gah! Get away from me!!",
                            "Omg, this person is too annoying!",
                            "Why are we even in the same room??",
                            "Get out! Get out! Get outttttt!!"
                        },
                        StoryGraphicCode.MochiCrazy
                    ),
                    new ConversationLine(
                        "Crab King Tester 2",
                        new List<string> {
                            "Yada yada.",
                            "If anyone has to leave it's you.",
                            "I can't bear your very existence either.",
                            "Why don't you just go and die?"
                        },
                        StoryGraphicCode.CrazyKing
                    ),
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "Oh I could say the same to you! Go die!!"
                        },
                        StoryGraphicCode.MochiCrazy
                    ),
                    new ConversationLine(
                        "Crab King Tester 2",
                        new List<string> {
                            "Ugh, how childish! But anyway",
                            "We are here together because you have chosen so.",
                            "Are you satisfied? We will forever stay in conflict.",
                            "But both of us will be your guide."
                        },
                        StoryGraphicCode.KingCrab
                    ),
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "And soon enough you will realize who is the better one.",
                            "And the other one will have no rights to exist at all. Kekeke~"
                        },
                        StoryGraphicCode.Mochi
                    ),
                    new ConversationLine(
                        "Crab King Tester 2",
                        new List<string> {
                            "Spelling your own future, how smart of you.",
                            "Could this be the first time ever that you actually use your brain?",
                            "I commend your effort, trash."
                        },
                        StoryGraphicCode.KingCrab
                    ),
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "YOU are the trash! Get OUTTTTT!!!!"
                        },
                        StoryGraphicCode.MochiCrazy
                    ),
                    new ConversationLine(
                        "Crab King Tester 2",
                        new List<string> {
                            "Disregarding that annoying yapping,",
                            "you have chosen the path in between.",
                            "It is going to be difficult with both of us here."
                        },
                        StoryGraphicCode.KingCrab
                    ),
                    new ConversationLine(
                        "Pink Mochi Tester 103",
                        new List<string> {
                            "But at the same time, there are endless possibilities.",
                            "So, who will you become?"
                        },
                        StoryGraphicCode.Mochi
                    )
                },
                new List<IProvideCondition>
                {
                    new SentimentCondition(CharacterCode.KingCrab,10,CharacterCode.Player),
                    new SentimentCondition(CharacterCode.Mochi,25,CharacterCode.Player),
                    new ConversationCondition(ConversationCode.AnotherGreeting)
                },
                new List<IProvideCondition>
                {
                },
                MilestoneCode.WhoIsYourGuide)
            #endregion
            // Next conversation?
        };
    }
}