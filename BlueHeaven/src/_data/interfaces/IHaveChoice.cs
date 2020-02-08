using System.Collections.Generic;
using BlueHeaven.src.Enums;
namespace BlueHeaven.src.Data
{
    /// <summary>
    /// Data object to contain choices (abstract)
    /// </summary>
    public interface IHaveChoice
    {
        /// <summary>
        /// Set chosen choice by index
        /// </summary>
        /// <param name="index"></param>
        void SetChoice(int index);

        /// <summary>
        /// Get chosen choice
        /// </summary>
        IChoice Chosen { get; }

        /// <summary>
        /// Get list of choices
        /// </summary>
        List<IChoice> Choices { get; }

        /// <summary>
        /// Get bool if identified by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool IsCalled(ChoiceDispenserCode code);
    }
}