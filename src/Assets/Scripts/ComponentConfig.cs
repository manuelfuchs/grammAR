using System;
using System.Collections.Generic;
using Assets.Scripts.Components.AudioPlayer;
using Assets.Scripts.Components.CurseWordFilter;
using Assets.Scripts.Components.Debug.TargetMapper;
using Assets.Scripts.Components.Debug.TargetTracker;
using Assets.Scripts.Components.OverlayPositionCalculator;
using Assets.Scripts.Components.SettingsComponent;
using Assets.Scripts.Components.SettingsPersistence;
using Assets.Scripts.Components.SpellChecker;
using Assets.Scripts.Components.TextExtractor;

namespace Assets.Scripts
{
    public class ComponentConfig
    {
        private static ComponentConfig instance = null;

        private readonly IDictionary<Type, Lazy<object>> serviceCollection;

        private ComponentConfig()
        {
            serviceCollection = new Dictionary<Type, Lazy<object>>();

            ConfigureServices();
        }

        public static ComponentConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ComponentConfig();
                }

                return instance;
            }
        }

        public TService GetService<TService>()
            where TService : class
        {
            if (serviceCollection.TryGetValue(typeof(TService), out var service))
            {
                return (TService) service.Value;
            }
            else
            {
                return null;
            }
        }

        public void RegisterService<TService>(object component)
        {
            serviceCollection[typeof(TService)] = new Lazy<object>(() => component);
        }

        private void ConfigureServices()
        {
            serviceCollection[typeof(IDebugTargetTracker)] = new Lazy<object>(() => new DefaultTargetTracker());
            serviceCollection[typeof(IDebugTargetMapper)] = new Lazy<object>(() => new DefaultTargetMapper());

            serviceCollection[typeof(ITextExtractor)] = new Lazy<object>(() => new MockTextExtractor());
            serviceCollection[typeof(ISpellChecker)] = new Lazy<object>(() => new MockSpellChecker());

            serviceCollection[typeof(ISettingsComponent)] = new Lazy<object>(() => new DefaultSettingsComponent());
            serviceCollection[typeof(IOverlayPositionCalculator)] =
                new Lazy<object>(() => new OverlayPositionCalculator());
            serviceCollection[typeof(IAudioPlayer)] = new Lazy<object>(() => new DefaultAudioPlayer());
            serviceCollection[typeof(ICurseWordFilter)] = new Lazy<object>(() => new MockCurseWordFilter());
            serviceCollection[typeof(ISettingsPersistence)] = new Lazy<object>(() => new SettingsPersistence());
        }
    }
}