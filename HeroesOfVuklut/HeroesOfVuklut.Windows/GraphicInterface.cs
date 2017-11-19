using HeroesOfVuklut.Windows.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HeroesOfVuklut.Engine.IO;
using HeroesOfVuklut.Engine.DI;

namespace HeroesOfVuklut.Windows
{
    [ServiceInject(typeof(GraphicInterface), typeof(IGraphicsInterface))]
    public class GraphicInterface : IGraphicsInterface
    {
        public IResourceProvider ResourceProvider { get; set; }
        public SpriteBatch Batch { get; set; }

        public void Draw(int x, int y, int w, int h, string resourceKey)
        {
            TextureInfo texture = ResourceProvider.GetTexture(resourceKey);
            Batch.Draw(texture.Texture, new Rectangle(x, y, w, h), Color.White);
        }

        public void Draw(int x, int y, int w, int h, string resourceKey, string frame)
        {
            TextureInfo texture = ResourceProvider.GetTextureFrame(resourceKey, frame);
            Batch.Draw(texture.Texture, new Rectangle(x, y, w, h), new Rectangle(texture.OffsetX, texture.OffsetY, texture.Width, texture.Heigth), Color.White);
        }

        public void DrawCircle(int x, int y)
        {
            TextureInfo texture = ResourceProvider.GetTexture("circle");
            Batch.Draw(texture.Texture, new Vector2(x, y), Color.White);
        }

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            TextureInfo texture = ResourceProvider.GetTexture("dot");
            Batch.Draw(texture.Texture, new Rectangle(x1, y1, x2 - x1 + 1, y2 - y1 + 1), Color.White);
        }

        public void DrawText(int x, int y, string text)
        {
            Batch.DrawString( ResourceProvider.Font() , text, new Vector2(x, y), Color.White);
        }
    }
}
