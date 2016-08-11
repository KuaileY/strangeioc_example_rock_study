
using strange.extensions.signal.impl;

namespace Assets.strangerocks
{
    public class StartSignal:Signal{}
    public class GameStartSignal : Signal { }
    public class LevelStartSignal : Signal { }
    public class LevelEndSignal : Signal { }
    public class GameEndSignal : Signal { }
    public class UpdateLivesSignal : Signal<int> { }
    public class UpdateScoreSignal : Signal<int> { }
    public class UpdateLevelSignal : Signal<int> { }
}
