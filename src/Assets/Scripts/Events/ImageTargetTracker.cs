using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
    public class ImageTargetTracker : DefaultTrackableEventHandler
    {
        protected override void OnTrackingFound()
        {
            base.OnTrackingFound();


        }

        protected override void OnTrackingLost()
        {
            base.OnTrackingLost();
        }
    }
}
