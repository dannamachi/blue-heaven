using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlueHeaven.src.Graphic;

namespace BlueHeaven.src.Enums
{
    /// <summary>
    /// Builder for story graphic
    /// </summary>
    public partial class GraphicBuilder
    {
        // change texture2d to other custom class if sprites?
        private static Dictionary<StoryGraphicCode, IGraphicObject> _storyGraphic = new Dictionary<StoryGraphicCode, IGraphicObject>();

        private static Dictionary<BackgroundCode, IGraphicObject> _bgGraphic = new Dictionary<BackgroundCode, IGraphicObject>();

        /// <summary>
        /// load external content, call on init/reset/reload
        /// </summary>
        /// <param name="storyGraphics"></param>
        /// <param name="backgrounds"></param>
        public static void LoadExternalGraphic(
            Dictionary<StoryGraphicCode,Texture2D> storyGraphics,
            Dictionary<BackgroundCode,Texture2D> backgrounds)
        {
            _storyGraphic = new Dictionary<StoryGraphicCode, IGraphicObject>();
            _bgGraphic = new Dictionary<BackgroundCode, IGraphicObject>();
            foreach (StoryGraphicCode storyCode in storyGraphics.Keys)
            {
                _storyGraphic[storyCode] = new GraphicObject(
                    "StoryGraphic", 
                    new GraphicSprite(storyGraphics[storyCode], GraphicDimension.GraphicFrame));
            }
            foreach (BackgroundCode bgCode in backgrounds.Keys)
            {
                _bgGraphic[bgCode] = new GraphicObject(
                    "Background",
                    new GraphicSprite(backgrounds[bgCode], GraphicDimension.GraphicFrame));
            }
        }

        /// <summary>
        /// Get graphic obj for story graphic based on code
        /// </summary>
        /// <param name="storyCode"></param>
        /// <returns></returns>
        public static IGraphicObject GetStoryGraphic(StoryGraphicCode storyCode)
        {
            if (_storyGraphic.ContainsKey(storyCode)) return _storyGraphic[storyCode];
            else return new GraphicObject(
                "StoryGraphicNull",
                new GraphicRectangle(_graphics, GraphicDimension.GraphicFrame, Color.Black));
        }

        /// <summary>
        /// Get graphic obj for background based on code
        /// </summary>
        /// <param name="bgCode"></param>
        /// <returns></returns>
        public static IGraphicObject GetBackground(BackgroundCode bgCode)
        {
            if (_bgGraphic.ContainsKey(bgCode)) return _bgGraphic[bgCode];
            else return new GraphicObject(
                "StoryGraphicNull",
                new GraphicRectangle(_graphics, GraphicDimension.GraphicFrame, Color.Black));
        }

    }
}
