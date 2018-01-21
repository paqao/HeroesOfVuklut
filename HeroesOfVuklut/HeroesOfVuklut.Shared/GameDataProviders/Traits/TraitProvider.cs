using System;
using HeroesOfVuklut.Engine.DI;
using HeroesOfVuklut.Shared.Traits;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace HeroesOfVuklut.Shared.GameDataProviders.Traits
{
    [ServiceInject(typeof(TraitProvider), typeof(ITraitProvider))]
    public class TraitProvider : ITraitProvider
    {
        private bool _isDataLoaded = false;

        private ICollection<ClassTrait> classesTraitsInfo;

        public ClassTrait GetClassTrait(string name)
        {
            if (!_isDataLoaded)
            {
                LoadData();
            }

            return classesTraitsInfo.FirstOrDefault(c => c.Name == name);
        }

        private void LoadData()
        {
            ClassTraitsInfo tmpClassInfo;
            using (var textReader = File.OpenText("data/classes.json"))
            {
                string fileContent = textReader.ReadToEnd();
                tmpClassInfo = JsonConvert.DeserializeObject<ClassTraitsInfo>(fileContent);
            }

            classesTraitsInfo = new List<ClassTrait>();

            foreach (var classTrait in tmpClassInfo.Classes)
            {
                ClassTrait trait = new ClassTrait();

                trait.Name = classTrait.Name;

                classesTraitsInfo.Add(trait);
            }
        }
    }
}
