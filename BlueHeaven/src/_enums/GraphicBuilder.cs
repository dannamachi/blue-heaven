using System.Collections.Generic;
using BlueHeaven.src.Graphic;
namespace BlueHeaven.src.Enums
{
    // enum: graphic object source
    public static class GraphicBuilder
    {
        private static Dictionary<string, List<IGraphicObject>> _graphicDict = new Dictionary<string, List<IGraphicObject>>();
        public static void DefineGraphic()
        {

        }
        private static List<IGraphicObject> GetGraphicForStory()
        {
            List<IGraphicObject> graphics = new List<IGraphicObject>();
            // round-edged rectangle, blue palette (StoryFrame)
            return graphics;
        }
        private static List<IGraphicObject> GetGraphicForChoice()
        {
            List<IGraphicObject> graphics = new List<IGraphicObject>();
            // 3 round-edged rectangles, blue palette (ChoiceBox1 ChoiceBox2 ChoiceBox3)  
            return graphics;
        }
        private static List<IGraphicObject> GetGraphicForNavigation()
        {
            List<IGraphicObject> graphics = new List<IGraphicObject>();
            // 4 sharp-edged rectangles, grey blue (ToggleButton1...4)  
            return graphics;
        }
    }
}