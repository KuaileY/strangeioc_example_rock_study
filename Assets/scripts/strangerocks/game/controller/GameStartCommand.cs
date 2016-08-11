using strange.extensions.command.impl;

namespace Assets.strangerocks.game
{
    public class GameStartCommand:Command
    {
        [Inject]
        public GameStartedSignal gameStartedSignal { get; set; }
        [Inject]
        public UpdateScoreSignal updateScoreSignal { get; set; }
        [Inject]
        public UpdateLivesSignal updateLivesSignal { get; set; }
        [Inject]
        public UpdateLevelSignal updateLevelSignal { get; set; }
        [Inject]
        public IGameConfig gameConfig { get; set; }
        [Inject]
        public IGameModel gameModel { get; set; }
        public override void Execute()
        {
            gameModel.initLives = gameConfig.initLives;
            gameModel.Reset();

            updateScoreSignal.Dispatch(gameModel.score);
            updateLivesSignal.Dispatch(gameModel.lives);
            updateLevelSignal.Dispatch(gameModel.level);

            gameStartedSignal.Dispatch();
        }
    }
}
