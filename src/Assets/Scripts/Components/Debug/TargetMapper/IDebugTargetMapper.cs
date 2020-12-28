using Assets.Scripts.Types;

namespace Assets.Scripts.Components.Debug
{
    public interface IDebugTargetMapper
    {
        DebugImageTarget? Map(string name);
    }
}
