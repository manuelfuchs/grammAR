using Assets.Scripts.Types;
using System;

namespace Assets.Scripts.Components.Debug
{
    public interface IDebugTargetTracker
    {
        event Action<DebugImageTarget?> OnVisibleTargetChanged;

        DebugImageTarget? VisibleTarget { get; set; }
    }
}
