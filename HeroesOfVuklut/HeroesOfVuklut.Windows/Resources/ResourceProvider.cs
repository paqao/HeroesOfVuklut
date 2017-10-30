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
        public Texture2D GetTexture(string resourceName)
        {
            var texture = _resourceDictionary.Textures.FirstOrDefault(x => String.Compare(resourceName.ToLower(), x.Key.Name.ToLower()) == 0);
            return texture.Value != null ? texture.Value : null;
        }

        public Texture2D GetTexture(string resourceName, string familyName)
        {
            throw new NotImplementedException();
        }

        public Texture2D GetTextureFrame(string resourceName, string frame)
        {
            throw new NotImplementedException();
        }

        public Texture2D GetTextureFrame(string resourceName, string familyName, string frame)
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

        Texture2D GetTexture(string resourceName);
        Texture2D GetTexture(string resourceName, string familyName);
        Texture2D GetTextureFrame(string resourceName, string frame);
        Texture2D GetTextureFrame(string resourceName, string familyName, string frame);
    }
}