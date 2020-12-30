using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.SpellChecker
{
    public class MockSpellChecker : ISpellChecker
    {
        private readonly IDictionary<string, IEnumerable<SpellingMistake>> mockedTextMistakes =
            new Dictionary<string, IEnumerable<SpellingMistake>>();

        public MockSpellChecker()
        {
            InitializeMockedTexts();
        }

        public Task<IEnumerable<SpellingMistake>> GetMistakes(IEnumerable<string> text)
        {
            return Task.FromResult(mockedTextMistakes[text.First()]);
        }

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
        }
    }
}