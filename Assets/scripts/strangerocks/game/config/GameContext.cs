using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.context.impl;
using strange.extensions.pool.api;
using strange.extensions.pool.impl;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class GameContext:SignalContext
    {
        public GameContext(MonoBehaviour contextView) : base(contextView)
        {
        }

        protected override void mapBindings()
        {
            base.mapBindings();
            if (Context.firstContext == this)
            {
                injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton();

                injectionBinder.Bind<UpdateLivesSignal>().ToSingleton();
                injectionBinder.Bind<UpdateScoreSignal>().ToSingleton();
                injectionBinder.Bind<UpdateLevelSignal>().ToSingleton();

                commandBinder.Bind<StartSignal>().To<GameIndependStartCommand>().Once();
            }
            else
            {
                commandBinder.Bind<StartSignal>().To<GameModuleStartCommand>().Once();
            }
            injectionBinder.Bind<IGameConfig>().To<GameConfig>().ToSingleton();
            injectionBinder.Bind<IPool<GameObject>>().To<Pool<GameObject>>().ToSingleton().ToName(GameElement.ROCK_POOL);
            injectionBinder.Bind<IPool<GameObject>>().To<Pool<GameObject>>().ToSingleton().ToName(GameElement.TEST_POOL);

            injectionBinder.Bind<GameStartedSignal>().ToSingleton();
            injectionBinder.Bind<LevelStartedSignal>().ToSingleton();

            commandBinder.Bind<GameStartSignal>().To<GameStartCommand>();
            
            commandBinder.Bind<CreatePlayerSignal>().To<CreatePlayerCommand>();
            commandBinder.Bind<CreateRockSignal>().To<CreateRockCommand>().Pooled();
            commandBinder.Bind<CreateTestSignal>().To<CreateTestcommand>().Pooled();
            commandBinder.Bind<DestroyPlayerSignal>().To<DestroyPlayerCommand>().Pooled();
            commandBinder.Bind<DestroyRockSignal>().To<DestroyRockCommand>().Pooled();
            commandBinder.Bind<GameEndSignal>().To<GameEndCommand>();

            commandBinder.Bind<LevelStartSignal>()
                .To<CreateGameFieldCommand>()
                .To<CleanupLevelCommand>()
                .To<StartLevelCommand>()
                .InSequence();
            commandBinder.Bind<SetupLevelSignal>()
                .To<SetupLevelCommand>();
            commandBinder.Bind<LevelEndSignal>()
                .To<CleanupLevelCommand>()
                .To<LevelEndCommand>()
                .InSequence();

            mediationBinder.Bind<GameDebugView>().To<GameDebugMediator>();
            mediationBinder.Bind<ShipView>().To<ShipMediator>();
            mediationBinder.Bind<RockView>().To<RockMediator>();
            mediationBinder.Bind<TestView>().To<TestMediator>();

        }

        protected override void postBindings()
        {
            Camera cam = (contextView as GameObject).GetComponentInChildren<Camera>();
            TestAssert.That(cam != null, "GameContext 没有发现场景摄像机");
            injectionBinder.Bind<Camera>().ToValue(cam).ToName(StrangeRocksElement.GAME_CAMERA);

            IPool<GameObject> rockPool = injectionBinder.GetInstance<IPool<GameObject>>(GameElement.ROCK_POOL);
            rockPool.instanceProvider = new ResourceInstanceProvider("rock", LayerMask.NameToLayer(MaskLayers.ENEMY.ToString()));
            rockPool.inflationType = PoolInflationType.INCREMENT;

            IPool<GameObject> testPool = injectionBinder.GetInstance<IPool<GameObject>>(GameElement.TEST_POOL);
            testPool.instanceProvider = new ResourceInstanceProvider("test", LayerMask.NameToLayer(MaskLayers.ENEMY.ToString()));
            testPool.inflationType = PoolInflationType.INCREMENT;

            base.postBindings();
        }
    }
}
