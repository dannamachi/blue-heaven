using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data
{
    // abstract: effect of choice on single ICharacter
    public interface IAffectCharacter
    {
        CharacterCode AffectWho { get; }
        void GiveEffect(ICharacter character);
    }
}