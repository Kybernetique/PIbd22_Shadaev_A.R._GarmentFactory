﻿using System.Collections.Generic;
using System.Reflection;

namespace GarmentFactoryContracts.StoragesContracts
{
    public interface IBackUpInfo
    {
        Assembly GetAssembly();

        List<PropertyInfo> GetFullList();
        
        List<T> GetList<T>() where T : class, new();
    }
}
