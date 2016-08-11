using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using UnityEngine;

namespace Assets.strangerocks
{
    public class SignalContext:MVCSContext
    {
        public SignalContext(MonoBehaviour contextView):base(contextView)
        {
        }

        public override void Launch()
        {
            base.Launch();
            StartSignal startSignal = (StartSignal) injectionBinder.GetInstance<StartSignal>();
            startSignal.Dispatch();
        }
        protected override void mapBindings()
        {
            base.mapBindings();
            implicitBinder.ScanForAnnotatedClasses(new string[] {"Assets.strangerocks"});
        }
    }
}
