using Assets.Scripts.Types;

namespace Assets.Scripts.Components.Debug.TargetMapper
{
    public interface IDebugTargetMapper
    {
        DebugImageTarget? Map(string name);
    }
}
