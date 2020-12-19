using Assets.Scripts.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Components
{
    public class MockSpellChecker : ISpellChecker
    {
        private readonly IDictionary<string, SpellingMistake[]> mockedTexts = new Dictionary<string, SpellingMistake[]>();

        public MockSpellChecker()
        {
            this.InitializeMockedTexts();
        }

        public IEnumerable<SpellingMistake> GetMistakes(IEnumerable<string> text)
        {
            return this.mockedTexts[text.First()];
        }

        private void InitializeMockedTexts()
        {
            this.mockedTexts.Add(new KeyValuePair<string, SpellingMistake[]>(
                "Anstatt immer nur zu kritisieren, legt die FPÖ heute erstmals eine",
                new SpellingMistake[]
                {

                }));
        }
    }
}
