using Assets.Scripts.Components;
using Assets.Scripts.Components.Debug;
using System;
using System.Collections.Generic;

public class ComponentConfig
{
    private static ComponentConfig instance = null;

    private readonly IDictionary<Type, object> serviceCollection;

    private ComponentConfig()
    {
        this.serviceCollection = new Dictionary<Type, object>();

        this.ConfigureServices();
    }

    public static ComponentConfig Instance
    {
        get
        {
            if (instance == null)
                instance = new ComponentConfig();
            return instance;
        }
    }

    public TService GetService<TService>()
        where TService : class
    {
        if (this.serviceCollection.TryGetValue(typeof(TService), out var instance))
            return (TService)instance;
        else
            return null;
    }

    private void ConfigureServices()
    {
        this.serviceCollection[typeof(ISpellChecker)] = new MockSpellChecker();
        this.serviceCollection[typeof(IDebugTargetTracker)] = new DefaultTargetTracker();
        this.serviceCollection[typeof(IDebugTargetMapper)] = new DefaultTargetMapper();
    }
}
