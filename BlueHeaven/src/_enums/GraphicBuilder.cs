using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlueHeaven.src.Graphic;
namespace BlueHeaven.src.Enums
{
    /// <summary>
    /// Builder for graphic objects
    /// </summary>
    public partial class GraphicBuilder
    {
        private static GraphicsDevice _graphics;
        private static Dictionary<string, List<IGraphicObject>> _graphicDict = new Dictionary<string, List<IGraphicObject>>();

        /// <summary>
        /// Build objects with graphicsdevice
        /// </summary>
        /// <param name="graphics"></param>
        public static void BuildObjects(GraphicsDevice graphics)
        {
            _graphics = graphics;
            _graphicDict = new Dictionary<string, List<IGraphicObject>>
                {
                    { "Story",GetGraphicForStory() },
                    { "Choice",GetGraphicForChoice() },
                    { "Personality",GetGraphicForPersonality() },
                    { "Navigation",GetGraphicForNavigation() },
                    { "Title",GetGraphicForTitle() },
                    { "Info",GetGraphicForInfo() }
                };
        }

        /// <summary>
        /// Get list of graphic object based on component name
        /// </summary>
        /// <param name="componentName"></param>
        /// <returns></returns>
        public static List<IGraphicObject> GetGraphics(string componentName)
        {
            if (_graphicDict.ContainsKey(componentName)) return _graphicDict[componentName];
            else return new List<IGraphicObject>();
        }

        /// <summary>
        /// Get list of graphic for info component
        /// </summary>
        /// <returns></returns>
        private static List<IGraphicObject> GetGraphicForInfo()
        {
            List<IGraphicObject> graphics = new List<IGraphicObject>();
            // round-edged rectangle, blue palette (StoryFrame)
            graphics.Add(new GraphicObject("InfoFrame",
                new GraphicRectangle(_graphics, GraphicDimension.InfoFrame, Color.BlueViolet),
                null));
            graphics.Add(new GraphicObject("UpButton",
                new GraphicRectangle(_graphics, GraphicDimension.UpButton, Color.DarkSeaGreen),
                new GraphicRectangle(_graphics, GraphicDimension.UpButton, Color.DarkTurquoise)));
            graphics.Add(new GraphicObject("DownButton",
                new GraphicRectangle(_graphics, GraphicDimension.DownButton, Color.DarkSeaGreen),
                new GraphicRectangle(_graphics, GraphicDimension.DownButton, Color.DarkTurquoise)));
            return graphics;
        }

        /// <summary>
        /// Get list of graphic based on title component
        /// </summary>
        /// <returns></returns>
        private static List<IGraphicObject> GetGraphicForTitle()
        {
            List<IGraphicObject> graphics = new List<IGraphicObject>();
            // 
            graphics.Add(new GraphicObject("TitleFrame",
                new GraphicRectangle(_graphics, GraphicDimension.TitleBackground, Color.Black),
                null));
            graphics.Add(new GraphicObject("HelpButton",
                new GraphicRectangle(_graphics, GraphicDimension.TitleHelp, Color.Yellow),
                new GraphicRectangle(_graphics, GraphicDimension.TitleHelp, Color.PaleVioletRed)));
            graphics.Add(new GraphicObject("CreditsButton",
                new GraphicRectangle(_graphics, GraphicDimension.TitleCredits, Color.Yellow),
                new GraphicRectangle(_graphics, GraphicDimension.TitleCredits, Color.PaleVioletRed)));
            graphics.Add(new GraphicObject("ReloadButton",
                new GraphicRectangle(_graphics, GraphicDimension.TitleReload, Color.Yellow),
                new GraphicRectangle(_graphics, GraphicDimension.TitleReload, Color.PaleVioletRed)));
            return graphics;
        }
        
        /// <summary>
        /// Get list of graphic objects for story component
        /// </summary>
        /// <returns></returns>
        private static List<IGraphicObject> GetGraphicForStory()
        {
            List<IGraphicObject> graphics = new List<IGraphicObject>();
            // round-edged rectangle, blue palette (StoryFrame)
            graphics.Add(new GraphicObject("StoryFrame",
                new GraphicRectangle(_graphics, GraphicDimension.StoryFrame, Color.Blue),
                null));
            return graphics;
        }

        /// <summary>
        /// Get list of graphic objects for choice component
        /// </summary>
        /// <returns></returns>
        private static List<IGraphicObject> GetGraphicForChoice()
        {
            List<IGraphicObject> graphics = new List<IGraphicObject>();
            // 3 round-edged rectangles, blue palette (ChoiceBox1 ChoiceBox2 ChoiceBox3)  
            graphics.Add(new GraphicObject("ChoiceBox1",
                new GraphicRectangle(_graphics, GraphicDimension.ChoiceBox1, Color.Blue),
                new GraphicRectangle(_graphics, GraphicDimension.ChoiceBox1, Color.DarkBlue)));
            graphics.Add(new GraphicObject("ChoiceBox2",
                new GraphicRectangle(_graphics, GraphicDimension.ChoiceBox2, Color.Blue),
                new GraphicRectangle(_graphics, GraphicDimension.ChoiceBox2, Color.DarkBlue)));
            graphics.Add(new GraphicObject("ChoiceBox3",
                new GraphicRectangle(_graphics, GraphicDimension.ChoiceBox3, Color.Blue),
                new GraphicRectangle(_graphics, GraphicDimension.ChoiceBox3, Color.DarkBlue)));
            return graphics;
        }

        /// <summary>
        /// Get list of graphic objects for personality component
        /// </summary>
        /// <returns></returns>
        private static List<IGraphicObject> GetGraphicForPersonality()
        {
            List<IGraphicObject> graphics = new List<IGraphicObject>();
            // frame
            graphics.Add(new GraphicObject("EditingFrame",
                new GraphicRectangle(_graphics, GraphicDimension.EditingFrame, Color.LightCoral),
                null));
            // 4 sharp-edged rectangles, grey blue (ToggleButton1...4)  
            graphics.Add(new GraphicObject("ToggleButton1",
                new GraphicRectangle(_graphics, GraphicDimension.ToggleButton1, Color.DarkOliveGreen),
                new GraphicRectangle(_graphics, GraphicDimension.ToggleButton1, Color.Gold)));
            graphics.Add(new GraphicObject("ToggleButton2",
                new GraphicRectangle(_graphics, GraphicDimension.ToggleButton2, Color.DarkOliveGreen),
                new GraphicRectangle(_graphics, GraphicDimension.ToggleButton2, Color.Gold)));
            graphics.Add(new GraphicObject("ToggleButton3",
                new GraphicRectangle(_graphics, GraphicDimension.ToggleButton3, Color.DarkOliveGreen),
                new GraphicRectangle(_graphics, GraphicDimension.ToggleButton3, Color.Gold)));
            graphics.Add(new GraphicObject("ToggleButton4",
                new GraphicRectangle(_graphics, GraphicDimension.ToggleButton4, Color.DarkOliveGreen),
                new GraphicRectangle(_graphics, GraphicDimension.ToggleButton4, Color.Gold)));
            // overlay
            graphics.Add(new GraphicObject("Overlay",
                new GraphicRectangle(_graphics, GraphicDimension.EditingFrame, Color.MediumPurple),
                null));
            return graphics;
        }

        /// <summary>
        /// Get list og graphic objects for navigation component
        /// </summary>
        /// <returns></returns>
        private static List<IGraphicObject> GetGraphicForNavigation()
        {
            List<IGraphicObject> graphics = new List<IGraphicObject>();
            // 3 round-edged rectangles, blue/yellow 
            graphics.Add(new GraphicObject("NavigationButton1",
                new GraphicRectangle(_graphics, GraphicDimension.NavigationTitle, Color.Cornsilk),
                new GraphicRectangle(_graphics, GraphicDimension.NavigationTitle, Color.DarkOrange)));
            graphics.Add(new GraphicObject("NavigationButton2",
                new GraphicRectangle(_graphics, GraphicDimension.NavigationReading, Color.Cornsilk),
                new GraphicRectangle(_graphics, GraphicDimension.NavigationReading, Color.DarkOrange)));
            graphics.Add(new GraphicObject("NavigationButton3",
                new GraphicRectangle(_graphics, GraphicDimension.NavigationSetting, Color.Cornsilk),
                new GraphicRectangle(_graphics, GraphicDimension.NavigationSetting, Color.DarkOrange)));
            return graphics;
        }
    }
}