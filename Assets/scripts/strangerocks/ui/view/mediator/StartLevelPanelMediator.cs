using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.mediation.impl;

namespace Assets.strangerocks.ui
{
    public class StartLevelPanelMediator:Mediator
    {
        [Inject]
        public StartLevelPanelView view { get; set; }
        [Inject]
        public LevelStartSignal levelStartSignal { get; set; }
        [Inject]
        public LevelEndSignal levelEndSignal { get; set; }
        [Inject]
        public UpdateLevelSignal updateLevelSignal { get; set; }
        [Inject]
        public GameStartSignal gameStartSignal { get; set; }
        public override void OnRegister()
        {
            view.proceedSignal.AddListener(onProceed);
            levelEndSignal.AddListener(show);
            gameStartSignal.AddListener(show);
            updateLevelSignal.AddListener(onLevelUpdate);

            view.Init();
            hide();
        }
        private void hide()
        {
            gameObject.SetActive(false);
        }
        private void show()
        {
            gameObject.SetActive(true);
        }
        private void onProceed()
        {
            hide();
            levelStartSignal.Dispatch();
        }
        private void onLevelUpdate(int value)
        {
            view.SetLevel(value);
        }
    }
}
