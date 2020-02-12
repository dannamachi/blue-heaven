using Microsoft.Xna.Framework.Input;
using BlueHeaven.src.Enums;
using System.Collections.Generic;

namespace BlueHeaven.src.Services
{
    /// <summary>
    /// Handles clicking detection
    /// </summary>
    public class ClickDetectingService
    {
        private MouseState _prevState, _currState;
        public ClickDetectingService()
        {
            _currState = Mouse.GetState();
        }

        /// <summary>
        /// Get snapshot of current mouse state
        /// </summary>
        public void SnapShot()
        {
            _prevState = _currState;
            _currState = Mouse.GetState();
        }

        /// <summary>
        /// Get index of area that is hovered
        /// </summary>
        /// <param name="areas"></param>
        /// <returns></returns>
        public int WhichIsHovered(List<int[]> areas)
        {
            float[] pos = MousePosition;
            for (int index = 0; index < areas.Count; index++)
            {
                if (CommonUtilities.IsValidClick((int)pos[0], (int)pos[1], areas[index])) return index;
            }
            return -1;
        }

        /// <summary>
        /// Get bool if area is hovered
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool IsHovered(int[] area)
        {
            float[] pos = MousePosition;
            return CommonUtilities.IsValidClick((int)pos[0], (int)pos[1], area);
        }

        /// <summary>
        /// Get index of area that is clicked
        /// </summary>
        /// <param name="areas"></param>
        /// <returns></returns>
        public int WhichIsClicked(List<int[]> areas)
        {
            if (_prevState.LeftButton == ButtonState.Released && _currState.LeftButton == ButtonState.Pressed)
            {
                float[] pos = MousePosition;
                for (int index = 0; index < areas.Count; index++)
                {
                    if (CommonUtilities.IsValidClick((int)pos[0], (int)pos[1], areas[index])) return index;
                }
            }
            return -1;
        }
        
        /// <summary>
        /// Get bool is mouse clicked over an area
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool IsClicked(int[] area)
        {
            if (_prevState.LeftButton == ButtonState.Released && _currState.LeftButton == ButtonState.Pressed)
            {
                float[] pos = MousePosition;
                return CommonUtilities.IsValidClick((int)pos[0], (int)pos[1], area);
            }
            else return false;
        }

        public float[] MousePosition
        {
            get
            {
                return new float[] { _currState.X, _currState.Y };
            }
        }
    }
}
