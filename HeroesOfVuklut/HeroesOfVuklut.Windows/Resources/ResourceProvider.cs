using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.IO;

namespace HeroesOfVuklut.Windows.Resources
{
    public class ResourceProvider : IResourceProvider
    {
        private ResourceDictionary _resourceDictionary = new ResourceDictionary();
        public TextureInfo GetTexture(string resourceName)
        {
            var texture = _resourceDictionary.Textures.FirstOrDefault(x => String.Compare(resourceName.ToLower(), x.Key.Name.ToLower()) == 0);
            if(texture.Value == null)
            {
                return null;
            }

            var textureInfo = new TextureInfo
            {
                Texture = texture.Value
            };

            return textureInfo;
        }

        public TextureInfo GetTexture(string resourceName, string familyName)
        {
            throw new NotImplementedException();
        }

        public TextureInfo GetTextureFrame(string resourceName, string frame)
        {
            var texture = _resourceDictionary.Textures.FirstOrDefault(x => String.Compare(resourceName.ToLower(), x.Key.Name.ToLower()) == 0);

            if (texture.Value == null)
            {
                return null;
            }

            var spriteInfo = texture.Key.Frames.First(x => x.Name == frame);
            var textureInfo = new TextureInfo
            {
                Texture = texture.Value,
                Heigth = texture.Key.FrameSizeY,
                Width = texture.Key.FrameSizeX,
                OffsetX = texture.Key.FrameSizeX * spriteInfo.PositionX,
                OffsetY = texture.Key.FrameSizeY * spriteInfo.PositionY
            };


            return textureInfo;
        }

        public TextureInfo GetTextureFrame(string resourceName, string familyName, string frame)
        {
            throw new NotImplementedException();
        }

        public void LoadTextures(ContentManager content)
        {
            _resourceDictionary.Clear();
            SpriteResourceConfiguration config = null;

            using (var textReader = File.OpenText(@"data/sprites.json"))
            {
                string fileContent = textReader.ReadToEnd();
                config = JsonConvert.DeserializeObject<SpriteResourceConfiguration>(fileContent);
            }

            foreach (var sprite in config.Sprites)
            {
                var texture = content.Load<Texture2D>(sprite.ContentPath);
                _resourceDictionary.Add(sprite, texture);
            }
        }
    }

    internal class SpriteResourceConfiguration
    {
        public ICollection<SpriteConfiguration> Sprites { get; set; } = new List<SpriteConfiguration>();
    }

    internal class SpriteConfiguration
    {
        public string Name { get; set; }
        public string[] Families { get; set; }
        public string ContentPath { get; set; }
        public int FrameSizeX { get; set; }
        public int FrameSizeY { get; set; }
        public ICollection<SpriteFrameConfiguration> Frames { get; set; } = new List<SpriteFrameConfiguration>();
    }

    internal class SpriteFrameConfiguration
    {
        public string Name { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }

    internal class ResourceDictionary
    {
        internal Dictionary<SpriteConfiguration, Texture2D> Textures { get; set; } = new Dictionary<SpriteConfiguration, Texture2D>();
        internal void Clear()
        {
            Textures.Clear();
        }

        public void Add(SpriteConfiguration configuration, Texture2D resourceItem)
        {
            Textures[configuration] = resourceItem;
        }
    }

    public interface IResourceProvider
    {
        void LoadTextures(ContentManager content);

        TextureInfo GetTexture(string resourceName);
        TextureInfo GetTexture(string resourceName, string familyName);
        TextureInfo GetTextureFrame(string resourceName, string frame);
        TextureInfo GetTextureFrame(string resourceName, string familyName, string frame);
    }

    public class TextureInfo
    {
        public Texture2D Texture { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
    }
}