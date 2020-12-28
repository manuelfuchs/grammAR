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
            get
            {
                return this.visibleTarget;
            }
            set
            {
                this.visibleTarget = value;

                if (this.OnVisibleTargetChanged != null)
                {
                    this.OnVisibleTargetChanged.Invoke(value);
                }
            }
        }
    }
}
