using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Components.TextExtractor;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.SpellChecker
{
    public class MockSpellChecker : ISpellChecker
    {
        private readonly IDictionary<string, IEnumerable<SpellingMistake>> mockedTextMistakes =
            new Dictionary<string, IEnumerable<SpellingMistake>>();

        public MockSpellChecker()
        {
            var textExtractor = ComponentConfig.Instance.GetService<ITextExtractor>();
            textExtractor.OnTextFound += ExtractSpellingMistakes;

            InitializeMockedTexts();
        }

        public event Action<IEnumerable<SpellingMistake>> OnMistakesFound;

        private void ExtractSpellingMistakes(IEnumerable<string> text)
        {
            var textList = text.ToList();

            if (textList.Any()
                && mockedTextMistakes.TryGetValue(textList.First(), out var mistakes))
            {
                if (this.OnMistakesFound != null)
                {
                    this.OnMistakesFound.Invoke(mistakes);
                }
            }
        }

        #region Spelling mistakes Initialization

        private void InitializeMockedTexts()
        {
            var texts = ComponentConfig.Instance.GetService<DebugTexts>();
            var spellingMistakes = ComponentConfig.Instance.GetService<SpellingMistakes>();
            mockedTextMistakes.Add(new KeyValuePair<string, IEnumerable<SpellingMistake>>(
                texts.GermanNoErrors.First(),
                new SpellingMistake[]
                {
                }));

            mockedTextMistakes.Add(new KeyValuePair<string, IEnumerable<SpellingMistake>>(
                texts.GermanErrors.First(), spellingMistakes.GermanSpellingMistakes));

            mockedTextMistakes.Add(new KeyValuePair<string, IEnumerable<SpellingMistake>>(
                texts.EnglishErrors.First(),
                spellingMistakes.EnglishSpellingMistakes));

            mockedTextMistakes.Add(new KeyValuePair<string, IEnumerable<SpellingMistake>>(
                texts.EnglishErrorsAndCurseWordsTarget.First(),
                spellingMistakes.EnglishErrorsAndCurseWordsSpellingMistakes));
        }

        #endregion
    }
}