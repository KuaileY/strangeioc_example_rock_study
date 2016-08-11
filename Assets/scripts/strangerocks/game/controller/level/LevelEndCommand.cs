using strange.extensions.command.impl;

namespace Assets.strangerocks.game
{
    public class LevelEndCommand:Command
    {
        public override void Execute()
        {
            TestLoadConfig.log.Debug("LevelEndCommand");
        }
    }
}
