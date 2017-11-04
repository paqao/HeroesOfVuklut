using HeroesOfVuklut.Shared;
using HeroesOfVuklut.Windows.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HeroesOfVuklut.Windows
{
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
    }
}
