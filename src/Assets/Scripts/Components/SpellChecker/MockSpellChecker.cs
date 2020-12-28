using Assets.Scripts.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Components
{
    public class MockSpellChecker : ISpellChecker
    {
        private readonly IDictionary<string, SpellingMistake[]> mockedTextMistakes = new Dictionary<string, SpellingMistake[]>();

        public MockSpellChecker()
        {
            this.InitializeMockedTexts();
        }

        public IEnumerable<SpellingMistake> GetMistakes(IEnumerable<string> text)
        {
            return this.mockedTextMistakes[text.First()];
        }

        private void InitializeMockedTexts()
        {
            this.mockedTextMistakes.Add(new KeyValuePair<string, SpellingMistake[]>(
                "Anstatt immer nur zu kritisieren, legt die FPÖ heute erstmals eine",
                new SpellingMistake[]
                {

                }));
            this.mockedTextMistakes.Add(new KeyValuePair<string, SpellingMistake[]>(
                "Österreichs Antwort auf Amazon kann sich sehen lasen: Mit dem ",
                new[]
                {
                    new SpellingMistake(1, 48,52, SpellingSeverity.Fatal, "lassen"),
                    new SpellingMistake(8, 1,5, SpellingSeverity.Fatal, "neues"),
                    new SpellingMistake(11, 50,55, SpellingSeverity.Fatal, "zurecht"),
                    new SpellingMistake(23, 62,65, SpellingSeverity.Low, "Bank"),
                    new SpellingMistake(29, 54,58, SpellingSeverity.Fatal, "sagen"),
                    new SpellingMistake(35, 15,19, SpellingSeverity.Middle, "unter"),
                    new SpellingMistake(44, 26,33, SpellingSeverity.Fatal, "passendes"),
                }));
        }
    }
}
