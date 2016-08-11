using strange.extensions.mediation.impl;

namespace Assets.strangerocks.ui
{
    public class IdlePanelMediator:Mediator
    {
        [Inject]
        public IdlePanelView view { get; set; }
        [Inject]
        public GameStartSignal gameStartSignal { get; set; }
        [Inject]
        public LevelStartSignal levelStartSignal { get; set; }
        public override void OnRegister()
        {
            view.Init();
            view.proceedSignal.AddListener(onProceed);
        }
        public override void OnRemove()
        {
            view.proceedSignal.RemoveListener(onProceed);
        }
        private void onProceed()
        {
            hide();
            gameStartSignal.Dispatch();
        }
        private void hide()
        {
            gameObject.SetActive(false);
        }
        private void show()
        {
            gameObject.SetActive(true);
        }
    }
}
