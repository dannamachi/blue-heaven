using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace BlueHeaven.src.Enums
{
    public enum FontEnum
    {
        Font20 = 20
    }
    /// <summary>
    /// Container for all game fonts
    /// </summary>
    public class GameFonts
    {
        private static Dictionary<FontEnum, SpriteFont> _fontDict = new Dictionary<FontEnum, SpriteFont>();

        /// <summary>
        /// Load fonts from outside - strict order of font list
        /// </summary>
        /// <param name="fonts"></param>
        public static void LoadFonts(List<SpriteFont> fonts)
        {
            if (fonts.Count > 0)
            {
                _fontDict[FontEnum.Font20] = fonts[0];
            }
        }

        /// <summary>
        /// Get sprite font based on font enum
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        public static SpriteFont GetFont(FontEnum font)
        {
            if (_fontDict.ContainsKey(font)) return _fontDict[font];
            else return null;
        }
    }
}
