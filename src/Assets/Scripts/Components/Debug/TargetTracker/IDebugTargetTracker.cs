using System;
using Assets.Scripts.Types;

namespace Assets.Scripts.Components.Debug.TargetTracker
{
    public interface IDebugTargetTracker
    {
        event Action<DebugImageTarget?> OnVisibleTargetChanged;

        DebugImageTarget? VisibleTarget { get; set; }
    }
}
