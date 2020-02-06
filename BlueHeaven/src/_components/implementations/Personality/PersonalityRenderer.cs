using System.Collections.Generic;
using System;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
namespace BlueHeaven.src.Components.Personality
{
    // renderer: draws personality editor
    public class PersonalityRenderer : IObjectRenderer
    {
        private List<IGraphicObject> _objects;
        public PersonalityRenderer(List<IGraphicObject> objects)
        {
            _objects = objects;
        }
        private int[] GetPersonality(int personality)
        {
            int remainder;
            int toggleOne, toggleTwo, toggleThree, toggleFour;
            int process = Math.DivRem(personality, 10, out remainder);
            toggleOne = process / 100;
            toggleTwo = (process - (toggleOne * 100)) / 10;
            toggleThree = process - toggleOne * 100 - toggleTwo * 10;
            toggleFour = remainder;
            return new int[] { toggleOne, toggleTwo, toggleThree, toggleFour };
        }
        public void Draw(IGameState gameState)
        {
            string[] toggleButtons = new string[] { "EditToggle1", "EditToggle2", "EditToggle3", "EditToggle4" };
            // draw greyed overlay if unable to edit
            if (!gameState.Editable)
            {

            }
            // draw content when there is character to edit
            if (gameState.EditingCharacter != null)
            {
                int[] personalityArray = GetPersonality(gameState.EditingCharacter.IsOfPersonality);
                foreach (IGraphicObject object1 in _objects)
                {
                    for (int i = 0; i < toggleButtons.Length; i++)
                    {
                        // draw personality toggle buttons
                        if (object1.IsCalled(toggleButtons[i]))
                        {
                            if (personalityArray[i] == 1) object1.Draw();
                            else object1.DrawAlternate();
                            break;
                        }
                        // draw gui objects/background
                        else
                        {
                            object1.Draw();
                        }
                    }
                }
            }
            // draw content when there is no character
            else
            {
                foreach (IGraphicObject object1 in _objects)
                {
                    for (int i = 0; i < toggleButtons.Length; i++)
                    {
                        // draw gui objects/background
                        if (!object1.IsCalled(toggleButtons[i]))
                        {
                            object1.Draw();
                            break;
                        }
                    }
                }
            }
        }
    }
}