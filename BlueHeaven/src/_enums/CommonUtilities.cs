using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BlueHeaven.src.Enums
{
    /// <summary>
    /// Common functions
    /// </summary>
    public class CommonUtilities
    {
        /// <summary>
        /// Draws a string at defined pos
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="sbatch"></param>
        public static void DrawFont(string text,FontEnum font,Vector2 position,Color color,SpriteBatch sbatch)
        {
            sbatch.Begin();
            sbatch.DrawString(GameFonts.GetFont(font), text, position, color);
            sbatch.End();
        }

        /// <summary>
        /// Get vector2 from int array
        /// </summary>
        /// <param name="dimensionInts"></param>
        /// <returns></returns>
        public static Vector2 GetPositionFromInt(int[] dimensionInts)
        {
            if (dimensionInts.Length < 1) return new Vector2(0, 0);
            return new Vector2(dimensionInts[0], dimensionInts[1]);
        }

        /// <summary>
        /// Get bool if mouse cursor is within boundary
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool IsValidClick(int x, int y, int[] boundary)
        {
            return x >= boundary[0] && y >= boundary[1] && x <= boundary[0] + boundary[2] && y <= boundary[1] + boundary[3];
        }
    }
}
