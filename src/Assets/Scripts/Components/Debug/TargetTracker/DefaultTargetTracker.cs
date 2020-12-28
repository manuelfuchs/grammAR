using Assets.Scripts.Types;
using System;

namespace Assets.Scripts.Components.Debug
{
    public class DefaultTargetTracker : IDebugTargetTracker
    {
        private DebugImageTarget? visibleTarget;

        public event Action<DebugImageTarget?> OnVisibleTargetChanged;

        public DebugImageTarget? VisibleTarget
        {
            get => visibleTarget;
            set
            {
                visibleTarget = value;
                OnVisibleTargetChanged?.Invoke(value);
            }
        }
    }
}
