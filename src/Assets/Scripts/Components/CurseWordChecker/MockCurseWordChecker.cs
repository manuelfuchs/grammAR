using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Components.SettingsComponent;
using Assets.Scripts.Components.TextExtractor;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.CurseWordChecker
{
    public class MockCurseWordChecker : ICurseWordChecker
    {
        private readonly ISettingsComponent settingsComponent;

        private readonly IDictionary<Language, IEnumerable<string>> mockedCurseWords = InitKnownCurseWords();

        public MockCurseWordChecker()
        {
            this.settingsComponent = ComponentConfig.Instance.GetService<ISettingsComponent>();
            var textExtractor = ComponentConfig.Instance.GetService<ITextExtractor>();
            textExtractor.OnTextFound += ExtractCurseWords;
        }

        public event Action<IEnumerable<CurseWord>> OnCurseWordsFound;

        private void ExtractCurseWords(IEnumerable<string> text)
        {
            if (this.settingsComponent.IsCurseWordBleepingEnabled)
            {
                var curseWords = mockedCurseWords[this.settingsComponent.Language];

                var foundCurseWords = new List<CurseWord>();

                var line = 1;
                foreach (var lineStr in text)
                {
                    foreach (var curseWord in curseWords)
                    {
                        if (lineStr.ToLower()
                            .Contains(curseWord.ToLower()))
                        {
                            var startIndex = lineStr.IndexOf(curseWord, StringComparison.OrdinalIgnoreCase);
                            var wordIndices = Enumerable.Range(startIndex, curseWord.Length);
                            if ((startIndex == 0 || lineStr[startIndex - 1] == ' ')
                                && wordIndices.All(i => lineStr[i] != ' '))
                            {
                                foundCurseWords.Add(
                                    new CurseWord(line,
                                        startIndex + 1,
                                        startIndex + 1 + curseWord.Length,
                                        CurseWordSeverity.Minor));
                            }
                        }
                    }

                    line++;
                }

                if (foundCurseWords.Any())
                {
                    this.OnCurseWordsFound?.Invoke(foundCurseWords);
                }
            }
        }

        #region Curseword Initialization

        private static IDictionary<Language, IEnumerable<string>> InitKnownCurseWords()
        {
            return new Dictionary<Language, IEnumerable<string>>
            {
                {
                    Language.English,
                    new List<string>
                    {
                        "ass",
                        "fucking",
                        "damn",
                        "idiot",
                        "degenerate",
                    }
                },
                {
                    Language.German,
                    new List<string>()
                    {
                        "scheiß",
                        "idiot",
                        "hurensohn",
                        "arschloch"
                    }
                }
            };
        }

        #endregion
    }
}