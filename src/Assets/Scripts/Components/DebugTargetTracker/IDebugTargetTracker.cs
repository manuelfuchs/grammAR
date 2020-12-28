using Assets.Scripts.Types;

namespace Assets.Scripts.Components
{
    public interface IDebugTargetTracker
    {
        DebugImageTarget? VisibleTarget { get; set; }
    }
}
