﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared
{
    public class FactionAspect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
    }

    public enum Color
    {
        Red,
        Yellow
    }
}
