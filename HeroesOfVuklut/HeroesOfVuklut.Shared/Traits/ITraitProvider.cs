﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Traits
{
    public interface ITraitProvider
    {
        ClassTrait GetClassTrait(string name);
    }
}
