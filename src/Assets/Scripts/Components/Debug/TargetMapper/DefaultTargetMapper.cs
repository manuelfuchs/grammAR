﻿using Assets.Scripts.Types;

namespace Assets.Scripts.Components.Debug.TargetMapper
{
    public class DefaultTargetMapper : IDebugTargetMapper
    {
        public DebugImageTarget? Map(string name)
        {
            switch (name)
            {
                case "CorrectTextTarget":
                    return DebugImageTarget.GermanNoErrors;
                case "ErrorTextTarget":
                    return DebugImageTarget.GermanErrors;
                case "GermanCurseWordTarget":
                    return DebugImageTarget.GermanCurseWords;
                case "EnglishErrorTarget":
                    return DebugImageTarget.EnglishErrors;
                case "EnglishCurseWordTarget":
                    return DebugImageTarget.EnglishCurseWords;
                case "EnglishNoErrorTarget":
                    return DebugImageTarget.EnglishNoErrors;
                default:
                    return null;
            }
        }
    }
}