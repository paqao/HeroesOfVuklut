using HeroesOfVuklut.Windows;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesOfVuklut.Shared.Factions
{
    public interface IFactionProvider : IConfigurationProvider
    {
        FactionAspect GetFaction(int id);
    }
}
