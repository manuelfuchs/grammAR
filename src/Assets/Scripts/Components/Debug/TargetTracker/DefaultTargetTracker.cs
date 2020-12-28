using Assets.Scripts.Types;

namespace Assets.Scripts.Components.Debug
{
    public class DefaultTargetTracker : IDebugTargetTracker
    {
        private DebugImageTarget? visibleTarget;

        public DebugImageTarget? VisibleTarget
        {
            get => this.visibleTarget;
            set
            {
                this.visibleTarget = value;
            }
        }
    }
}
