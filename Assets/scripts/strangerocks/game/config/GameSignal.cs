using strange.extensions.signal.impl;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class GameStartedSignal : Signal { }
    public class CreatePlayerSignal : Signal { }
    public class SetupLevelSignal : Signal { }
    public class CreateRockSignal : Signal<int,Vector2>{ }
    public class CreateTestSignal : Signal<int, Vector2> { }
    public class LevelStartedSignal : Signal { }
    public class DestroyPlayerSignal : Signal<ShipView, bool> { }
    public class DestroyRockSignal : Signal<RockView, bool> { }

}
