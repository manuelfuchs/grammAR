using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Components.Debug.TargetTracker;
using Assets.Scripts.Components.SettingsComponent;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.TextExtractor
{
    public class MockTextExtractor : ITextExtractor
    {
        public event Action<IEnumerable<string>> OnTextFound;
        public event Action OnTextLost;

        private ISettingsComponent settings;

        public MockTextExtractor()
        {
            settings = ComponentConfig.Instance.GetService<ISettingsComponent>();
            var debugTargetTracker = ComponentConfig.Instance.GetService<IDebugTargetTracker>();
            debugTargetTracker.OnVisibleTargetChanged += target =>
            {
                if (target == null)
                {
                    OnTextLost?.Invoke();
                }
                else
                {
                    var text = GetMockText(target);
                    OnTextFound?.Invoke(text);
                }
            };
        }

        private IEnumerable<string> GetMockText(DebugImageTarget? target)
        {
            var debugTexts = ComponentConfig.Instance.GetService<DebugTexts>();
            var lang = settings.Language;
            if ((target == DebugImageTarget.EnglishErrors ||
                 target == DebugImageTarget.EnglishCurseWords ||
                 target == DebugImageTarget.EnglishNoErrors ||
                 target == DebugImageTarget.EnglishErrorsAndCurseWordsTarget)
                && lang != Language.English ||
                (target == DebugImageTarget.GermanErrors ||
                 target == DebugImageTarget.GermanCurseWords ||
                 target == DebugImageTarget.GermanNoErrors)
                && lang != Language.German)
            {
                return Enumerable.Empty<string>();
            }

            switch (target)
            {
                case DebugImageTarget.GermanNoErrors:
                    return debugTexts.GermanNoErrors;
                case DebugImageTarget.GermanErrors:
                    return debugTexts.GermanErrors;
                case DebugImageTarget.GermanCurseWords:
                    return debugTexts.GermanCurseWords;
                case DebugImageTarget.EnglishErrors:
                    return debugTexts.EnglishErrors;
                case DebugImageTarget.EnglishErrorsAndCurseWordsTarget:
                    return debugTexts.EnglishErrorsAndCurseWordsTarget;
                default:
                    return Enumerable.Empty<string>();
            }
        }
    }
}