
using System;
using Assets.scripts.strangerocks.ui.controller;
using strange.extensions.context.impl;
using UnityEngine;

namespace Assets.strangerocks.ui
{
    public class UIContext:SignalContext
    {
        public UIContext(MonoBehaviour contextView):base(contextView)
        {
        }
        protected override void mapBindings()
        {
            base.mapBindings();
            if (Context.firstContext == this)
            {
                injectionBinder.Bind<GameEndSignal>().ToSingleton();
                injectionBinder.Bind<GameStartSignal>().ToSingleton();
                injectionBinder.Bind<LevelStartSignal>().ToSingleton();
                injectionBinder.Bind<LevelEndSignal>().ToSingleton();
                injectionBinder.Bind<UpdateLevelSignal>().ToSingleton();
                injectionBinder.Bind<UpdateLivesSignal>().ToSingleton();
                injectionBinder.Bind<UpdateScoreSignal>().ToSingleton();
            }
            commandBinder.Bind<StartSignal>().To<UIStartCommand>();


            mediationBinder.Bind<ButtonView>().To<ButtonMouseMediator>();
            mediationBinder.Bind<IdlePanelView>().To<IdlePanelMediator>();
            mediationBinder.Bind<StartLevelPanelView>().To<StartLevelPanelMediator>();
            mediationBinder.Bind<EndGamePanelView>().To<EndGamePanelMediator>();
        }

        protected override void postBindings()
        {
            Camera cam = (contextView as GameObject).GetComponentInChildren<Camera>();
            if (cam == null)
                throw new Exception("不能发现UI摄像机");
            injectionBinder.Bind<Camera>().ToValue(cam).ToName(StrangeRocksElement.GAME_CAMERA);
            base.postBindings();


        }
    }
}
