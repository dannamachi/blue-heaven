using System.Collections.Generic;
using BlueHeaven.src.Components.Story;
using BlueHeaven.src.Data.Package;
using BlueHeaven.src.Data;

namespace BlueHeaven.src.Enums
{
    /// <summary>
    /// Load game data based on PackageCode
    /// </summary>
    public class PackageBuilder
    {
        private static List<IPackage> _packages = new List<IPackage>
        {
            #region Test Package
            new GamePackage(
                PackageCode.Test,
                new List<CharacterCode>
                {
                    CharacterCode.Mochi,
                    CharacterCode.KingCrab,
                    CharacterCode.Player
                },
                new List<ConversationCode>
                {
                    ConversationCode.WelcomeToBlueHeaven,
                    ConversationCode.AnotherGreeting,
                    ConversationCode.WillYouBeTheTrueYou,
                    ConversationCode.YouHaveBeenGood,
                    ConversationCode.WhoAreYou
                },
                new Dictionary<ConversationCode, CharacterCode>
                {
                    { ConversationCode.WelcomeToBlueHeaven,CharacterCode.Player },
                    { ConversationCode.AnotherGreeting,CharacterCode.Mochi },
                    { ConversationCode.WhoAreYou,CharacterCode.Player }
                })
            #endregion
        };

        /// <summary>
        /// Load GameState data based on PackageCode
        /// </summary>
        /// <param name="gameState"></param>
        /// <param name="code"></param>
        public static bool LoadPackage(IGameState gameState, PackageCode code)
        {
            IPackage package = null;
            foreach (IPackage pack in _packages)
            {
                if (pack.Code == code) package = pack;
            }
            if (package == null) return false;
            gameState.LoadData(CharacterBuilder.GetCharacters(package.Characters), package.EditingIndex);
            return true;
        }

        /// <summary>
        /// Load Story based on PackageCode
        /// </summary>
        /// <param name="component"></param>
        /// <param name="code"></param>
        public static bool LoadConversation(StoryComponent component, PackageCode code)
        {
            IPackage package = null;
            foreach (IPackage pack in _packages)
            {
                if (pack.Code == code) package = pack;
            }
            if (package == null) return false;
            component.SetConversation(package.Conversations);
            return true;
        }
    }
}
