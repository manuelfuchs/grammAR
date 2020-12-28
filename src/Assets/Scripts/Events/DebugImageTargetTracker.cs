using Assets.Scripts.Components;

namespace Assets.Scripts.Events
{
    public class DebugImageTargetTracker : DefaultTrackableEventHandler
    {
        private IDebugTargetMapper targetMapper;
        private IDebugTargetTracker targetTracker;

        private void Awake()
        {
            this.targetMapper = ComponentConfig.Instance.GetService<IDebugTargetMapper>();
            this.targetTracker = ComponentConfig.Instance.GetService<IDebugTargetTracker>();
        }

        protected override void OnTrackingFound()
        {
            base.OnTrackingFound();

            this.targetTracker.VisibleTarget = this.targetMapper.Map(this.gameObject.name);
        }

        protected override void OnTrackingLost()
        {
            base.OnTrackingLost();

            if (this.targetTracker.VisibleTarget == this.targetMapper.Map(this.gameObject.name))
                this.targetTracker.VisibleTarget = null;
        }
    }
}
