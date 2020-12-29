using Assets.Scripts.Types;

namespace Assets.Scripts.Components.Debug.TargetMapper
{
    public class DefaultTargetMapper : IDebugTargetMapper
    {
        public DebugImageTarget? Map(string name)
        {
            switch (name)
            {
                case "CorrectTextTarget":
                    return DebugImageTarget.Target1;
                case "ErrorTextTarget":
                    return DebugImageTarget.Target2;
                default:
                    return null;
            }
        }
    }
}
