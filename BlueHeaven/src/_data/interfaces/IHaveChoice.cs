using System.Collections.Generic;
namespace BlueHeaven.src.Data
{
    // abstract: container of possible IChoice
    public interface IHaveChoice
    {
        void SetChoice(int index);
        IChoice Chosen { get; }
        List<IChoice> Choices { get; }
    }
}