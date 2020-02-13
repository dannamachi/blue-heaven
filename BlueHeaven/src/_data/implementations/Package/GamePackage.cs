using System.Collections.Generic;
using BlueHeaven.src.Enums;

namespace BlueHeaven.src.Data.Package
{
    /// <summary>
    /// Stores data for a game package
    /// </summary>
    public class GamePackage : IPackage
    {
        private PackageCode _code;
        private List<CharacterCode> _chars;
        private List<ConversationCode> _convs;
        private Dictionary<ConversationCode, CharacterCode> _edits;
        public GamePackage(
            PackageCode code,
            List<CharacterCode> characters,
            List<ConversationCode> conversations,
            Dictionary<ConversationCode,CharacterCode> edits)
        {
            _code = code;
            _chars = characters;
            _convs = conversations;
            _edits = edits;
        }

        public PackageCode Code { get => _code; }

        public List<CharacterCode> Characters { get => _chars; }

        public List<ConversationCode> Conversations { get => _convs; }

        public Dictionary<ConversationCode,CharacterCode> EditingIndex { get => _edits; }
    }
}
