namespace BlueHeaven.src.Data
{
    // abstract: effect of choice on single ICharacter
    public interface IAffectCharacter
    {
        string AffectWho { get; }
        void GiveEffect(ICharacter character);
    }
}