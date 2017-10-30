using HeroesOfVuklut.Shared;
using HeroesOfVuklut.Windows.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfVuklut.Windows
{
    public class GraphicInterface : IGraphicsInterface
    {
        public IResourceProvider ResourceProvider { get; set; }
        public SpriteBatch Batch { get; set; }

        public void Draw(int x, int y, int w, int h, string resourceKey)
        {
            Texture2D texture = ResourceProvider.GetTexture(resourceKey);
            Batch.Draw(texture, new Rectangle(x, y, w, h), Color.White);
        }
    }
}
