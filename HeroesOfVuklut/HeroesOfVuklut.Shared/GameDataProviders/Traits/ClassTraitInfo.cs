using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.GameDataProviders.Traits
{
    public class ClassTraitInfo : TraitInfo
    {
        public string Color { get; set; }
    }

    public class ClassTraitsInfo
    {
        public ICollection<ClassTraitInfo> Classes { get; set; }
    }
}
