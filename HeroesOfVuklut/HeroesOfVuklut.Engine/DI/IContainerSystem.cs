﻿using HeroesOfVuklut.Engine.Scenes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HeroesOfVuklut.Engine.DI
{
    public interface IContainerSystem
    {
        void AddDeclaration<T, U>() where T : class, U;
        void AddDeclaration<T>() where T : class;

        T AddScene<T>() where T : SceneManager<T>;

        T Resolve<T>() where T : class;
        void AddAttributeDeclarations(Assembly source);
    }
}