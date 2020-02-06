using System.Collections.Generic;
using BlueHeaven.src.Graphic;
using BlueHeaven.src.Components;
using BlueHeaven.src.Data;
namespace BlueHeaven.src.Components.Story
{
    // renderer: draw speaker name and speech content
    public class StoryRenderer : IObjectRenderer
    {
        private List<IGraphicObject> _objects;
        public StoryRenderer(List<IGraphicObject> objects)
        {
            _objects = objects;
        }
        public void Draw(IGameState gameState)
        {
            foreach (IGraphicObject object1 in _objects)
            {
                object1.Draw();
            }
            //gameState.Conversation.GetConversationLine().Speaker; // TO DO: draw speaker
            //gameState.Conversation.GetConversationLine().Sentence; // TO DO: draw sentence 
        }
    }
}