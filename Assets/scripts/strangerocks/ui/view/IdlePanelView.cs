using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Assets.strangerocks.ui
{
    public class IdlePanelView:View
    {
        [Inject]
        public IScreenUtil screenUtil { get; set; }
        public ButtonView startButton;
        internal Signal proceedSignal = new Signal();
        public ScreenAnchor horizontalAnchor = ScreenAnchor.CENTER_HORIZONTAL;
        public ScreenAnchor verticalanchor = ScreenAnchor.CENTER_VERTICAL;
        internal void Init()
        {
            startButton.releaseSignal.AddListener(onStartClick);
            transform.localPosition = screenUtil.GetAnchorPosition(horizontalAnchor, verticalanchor);
        }

        private void onStartClick()
        {
            proceedSignal.Dispatch();
        }
    }
}
