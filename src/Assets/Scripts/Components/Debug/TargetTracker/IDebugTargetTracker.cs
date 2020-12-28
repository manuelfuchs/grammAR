using Assets.Scripts.Types;

namespace Assets.Scripts.Components.Debug
{
    public interface IDebugTargetTracker
    {
        DebugImageTarget? VisibleTarget { get; set; }
    }
}
