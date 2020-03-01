using System.Collections.Generic;
using BlueHeaven.src.Enums;

namespace BlueHeaven.src.Data.Package
{
    /// <summary>
    /// Enum to identify game package
    /// </summary>
    public enum PackageCode
    {
        None,
        Test
    }

    /// <summary>
    /// File to separate game packages
    /// </summary>
    public interface IPackage 
    {
        PackageCode Code { get; }
        List<CharacterCode> Characters { get; }
        List<ConversationCode> Conversations { get; }
        Dictionary<ConversationCode,CharacterCode> EditingIndex { get; }
    }
}
