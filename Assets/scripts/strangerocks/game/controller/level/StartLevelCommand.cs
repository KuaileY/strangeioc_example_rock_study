using strange.extensions.command.impl;

namespace Assets.strangerocks.game
{
    public class StartLevelCommand:Command
    {
        [Inject]
        public SetupLevelSignal setupLevelSignal { get; set; }
        [Inject]
        public LevelStartedSignal levelStartedSignal { get; set; }
        [Inject]
        public IGameModel gameModel { get; set; }
        [Inject]
        public UpdateLivesSignal updateLivesSignal { get; set; }
        public override void Execute()
        {
            setupLevelSignal.Dispatch();
            gameModel.levelInProgress = true;
            levelStartedSignal.Dispatch();
            updateLivesSignal.Dispatch(gameModel.lives);
        }
    }
}
