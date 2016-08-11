using strange.extensions.command.impl;

namespace Assets.strangerocks.game
{
    public class GameEndCommand:Command
    {
        public override void Execute()
        {
            TestLoadConfig.log.Trace("GameEnd");
        }
    }
}
