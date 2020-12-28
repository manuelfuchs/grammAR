using Assets.Scripts.Components.Debug;

namespace Assets.Scripts.Events
{
    public class DebugImageTargetTracker : DefaultTrackableEventHandler
    {
        private IDebugTargetMapper targetMapper;
        private IDebugTargetTracker targetTracker;

        private void Awake()
        {
            targetMapper = ComponentConfig.Instance.GetService<IDebugTargetMapper>();
            targetTracker = ComponentConfig.Instance.GetService<IDebugTargetTracker>();
        }

        protected override void OnTrackingFound()
        {
            base.OnTrackingFound();

            targetTracker.VisibleTarget = targetMapper.Map(gameObject.name);
        }

        protected override void OnTrackingLost()
        {
            base.OnTrackingLost();

            if (targetTracker.VisibleTarget == targetMapper.Map(gameObject.name))
                targetTracker.VisibleTarget = null;
        }
    }
}
