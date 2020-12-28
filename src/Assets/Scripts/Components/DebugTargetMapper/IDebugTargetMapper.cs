using Assets.Scripts.Types;

namespace Assets.Scripts.Components
{
    public interface IDebugTargetMapper
    {
        DebugImageTarget? Map(string name);
    }
}
