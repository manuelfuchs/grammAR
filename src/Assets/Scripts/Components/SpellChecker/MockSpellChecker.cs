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
            if (text.Any()
                && mockedTextMistakes.TryGetValue(text.First(), out var mistakes))
            {
                this.OnMistakesFound?.Invoke(mistakes);
            }
        }

        #region Spelling mistakes Initialization

        private void InitializeMockedTexts()
        {
            mockedTextMistakes.Add(new KeyValuePair<string, IEnumerable<SpellingMistake>>(
                "Anstatt immer nur zu kritisieren, legt die FPÖ",
                new SpellingMistake[]
                {
                }));

            mockedTextMistakes.Add(new KeyValuePair<string, IEnumerable<SpellingMistake>>(
                "Österreichs Antwort auf Amazon kann sich sehen",
                new[]
                {
                    new SpellingMistake(2, 1, 6, SpellingSeverity.Minor, "lassen"),
                    new SpellingMistake(10, 16, 21, SpellingSeverity.Fatal, "neues"),
                    new SpellingMistake(15, 20, 26, SpellingSeverity.Fatal, "zurecht"),
                    new SpellingMistake(31, 13, 18, SpellingSeverity.Minor, "Bank"),
                    new SpellingMistake(39, 20, 25, SpellingSeverity.Fatal, "sagen"),
                    new SpellingMistake(46, 1, 6, SpellingSeverity.Minor, "unter"),
                }));

            mockedTextMistakes.Add(new KeyValuePair<string, IEnumerable<SpellingMistake>>(
                "Auspicious tidings have come our way, OGN readers.",
                new[]
                {
                    new SpellingMistake(7, 1, 10, SpellingSeverity.Fatal, "DualSense"),
                    new SpellingMistake(8, 14, 20, SpellingSeverity.Fatal, "leaves"),
                    new SpellingMistake(14, 40, 45, SpellingSeverity.Fatal),
                    new SpellingMistake(21, 20, 29, SpellingSeverity.Fatal, "DualSense"),
                }));

            mockedTextMistakes.Add(new KeyValuePair<string, IEnumerable<SpellingMistake>>(
                "EAGAN, MN—Intimidated yet intrigued as he",
                new[]
                {
                    new SpellingMistake(8, 45, 51, SpellingSeverity.Fatal, "palms"),
                    new SpellingMistake(4, 11, 19, SpellingSeverity.Minor, "Thursday"),
                    new SpellingMistake(9, 1, 9, SpellingSeverity.Fatal),
                }));
        }

        #endregion
    }
}