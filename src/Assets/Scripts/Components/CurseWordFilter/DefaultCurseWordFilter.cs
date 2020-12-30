using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.CurseWordFilter
{
    public class DefaultCurseWordFilter : ICurseWordFilter
    {
        private IDictionary<Language, IList<string>> knownCurseWords = InitKnownCurseWords();

        public IEnumerable<CurseWord> FindCurseWords(IEnumerable<string> text, Language language)
        {
            var curseWords = knownCurseWords[language];
            var foundCurseWords = new List<CurseWord>();

            var line = 1;
            foreach (var lineStr in text)
            {
                foreach (var curseWord in curseWords)
                {
                    if (lineStr.ToLower().Contains(curseWord.ToLower()))
                    {
                        var startIndex = lineStr.IndexOf(curseWord, StringComparison.OrdinalIgnoreCase);
                        foundCurseWords.Add(
                            new CurseWord(line,
                                startIndex + 1,
                                startIndex + 1 + curseWord.Length,
                                CurseWordSeverity.Minor));
                    }
                }

                line++;
            }

            return foundCurseWords;
        }

        private static IDictionary<Language, IList<string>> InitKnownCurseWords()
        {
            return new Dictionary<Language, IList<string>>
            {
                {
                    Language.English,
                    new List<string>
                    {
                        "thicc ass",
                        "fucking",
                        "damn"
                    }
                },
                {
                    Language.German,
                    new List<string>()
                    {
                        "scheiß",
                        "idiot",
                    }
                }
            };
        }
    }
}