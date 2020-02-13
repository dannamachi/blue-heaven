using System.Collections.Generic;
using System;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
using BlueHeaven.src.Graphic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using BlueHeaven.src.Enums;

namespace BlueHeaven.src.Components.Personality
{
    /// <summary>
    /// Renders the personality editor component
    /// </summary>
    public class PersonalityRenderer : IObjectRenderer
    {
        private List<IGraphicObject> _objects;
        private List<IGraphicObject> _buttons;
        private IGraphicObject _overlay;
        private SpriteBatch _sbatch;
        public PersonalityRenderer(List<IGraphicObject> objects, SpriteBatch sbatch)
        {
            _sbatch = sbatch;
            string[] toggleButtons = new string[] { "ToggleButton1", "ToggleButton2", "ToggleButton3", "ToggleButton4" };
            _objects = new List<IGraphicObject>();
            _buttons = new List<IGraphicObject>();
            foreach (IGraphicObject object1 in objects)
            {
                if (object1.IsCalled("Overlay")) { _overlay = object1; }
                else
                {
                    for (int i = 0; i < toggleButtons.Length; i++)
                    {
                        if (object1.IsCalled(toggleButtons[i])) { _buttons.Add(object1); break; }
                        else { _objects.Add(object1); }
                    }
                }
            }
        }

        /// <summary>
        /// (P) Get list containing 4 digits representing personality
        /// </summary>
        /// <param name="personality"></param>
        /// <returns></returns>
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

        /// <summary>
        /// (P) Update alternate status of toggle buttons
        /// </summary>
        /// <param name="personality"></param>
        private void UpdateAlternateState(int personality)
        {
            int[] personalityArray = GetPersonality(personality);
            for (int i = 0; i < 4; i++)
            {
                _buttons[i].IsAlternate = !(personalityArray[i] == 1);
            }
        }

        /// <summary>
        /// Draws the component
        /// </summary>
        /// <param name="gameState"></param>
        public void Draw(IGameState gameState)
        {
            // draw content when there is character to edit
            foreach (IGraphicObject obj in _objects) { obj.Draw(_sbatch); }
            if (gameState.EditingCharacter != null)
            {
                UpdateAlternateState(gameState.EditingCharacter.IsOfPersonality);
                foreach (IGraphicObject obj in _buttons) { obj.Draw(_sbatch); }
            }
            // draw greyed overlay if unable to edit
            if (!gameState.Editable)
            {
                _overlay.Draw(_sbatch);
                CommonUtilities.DrawFont(
                    "Are you looking for something?",
                    FontEnum.Font20,
                    CommonUtilities.GetPositionFromInt(GraphicDimension.ToggleButton1),
                    Color.Black,
                    _sbatch);

            }

            // DEBUG
            if (gameState.EditingCharacter != null)
            {
                CommonUtilities.DrawFont(
                    gameState.EditingCharacter.IsOfPersonality.ToString(),
                    FontEnum.Font20,
                    new Vector2(50,50),
                    Color.Black,
                    _sbatch);
                CommonUtilities.DrawFont(
                    gameState.EditingCharacter.Name,
                    FontEnum.Font20,
                    new Vector2(100, 100),
                    Color.Black,
                    _sbatch);
            }
        }
    }
}