using strange.extensions.mediation.impl;

namespace Assets.strangerocks.game
{
    public class GameDebugMediator:Mediator
    {
        [Inject]
        public GameDebugView view { get; set; }
        [Inject]
        public GameStartSignal gameStartSignal { get; set; }
        [Inject]
        public GameStartedSignal gameStartedSignal { get; set; }
        [Inject]
        public LevelStartSignal levelStartSignal { get; set; }
        [Inject]
        public LevelStartedSignal levelStartedSignal { get; set; }
        [Inject]
        public GameEndSignal gameEndSignal { get; set; }
        [Inject]
        public UpdateLivesSignal updateLivesSignal { get; set; }
        [Inject]
        public UpdateScoreSignal updateScoreSignal { get; set; }
        [Inject]
        public UpdateLevelSignal updateLevelSignal { get; set; }

        public override void OnRegister()
        {
            view.startGameSignal.AddListener(onStartGameClick);
            view.startLevelSignal.AddListener(onStartLevelClick);

            updateLivesSignal.AddListener(onLivesUpdate);
            updateScoreSignal.AddListener(onScoreUpdate);
            updateLevelSignal.AddListener(onLevelUpdate);
            levelStartedSignal.AddListener(onLevelStarted);
            gameEndSignal.AddListener(onGameEnded);
            gameStartedSignal.AddListener(onGameStarted);
        }


        public override void OnRemove()
        {
            view.startGameSignal.RemoveListener(onStartGameClick);
            view.startLevelSignal.RemoveListener(onStartLevelClick);

            updateScoreSignal.RemoveListener(onScoreUpdate);
            updateLivesSignal.RemoveListener(onLivesUpdate);
            updateLevelSignal.AddListener(onLevelUpdate);
            levelStartedSignal.RemoveListener(onLevelStarted);
            gameEndSignal.RemoveListener(onGameEnded);
            gameStartedSignal.RemoveListener(onGameStarted);
        }

        private void onLevelUpdate(int value)
        {
            view.SetLevel(value);
        }

        private void onScoreUpdate(int value)
        {
            view.SetScore(value);
        }

        private void onLivesUpdate(int value)
        {
            view.SetLives(value);
        }

        private void onGameEnded()
        {
            view.SetState(GameDebugView.ScreenState.END_GAME);
        }
        private void onLevelStarted()
        {
            view.SetState(GameDebugView.ScreenState.LEVEL_IN_PROGRESS);
        }

        private void onGameStarted()
        {
            view.SetState(GameDebugView.ScreenState.START_LEVEL);
        }

        private void onStartLevelClick()
        {
            levelStartSignal.Dispatch();
        }

        private void onStartGameClick()
        {
            gameStartSignal.Dispatch();
        }
    }
}
