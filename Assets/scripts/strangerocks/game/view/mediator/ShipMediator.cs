using strange.extensions.mediation.impl;

namespace Assets.strangerocks.game
{
    public class ShipMediator:Mediator
    {
        [Inject]
        public ShipView view { get; set; }
        [Inject]
        public DestroyPlayerSignal destroyPlayerSignal { get; set; }

        public override void OnRegister()
        {
            view.collisionSignal.AddListener(onCollision);
        }

        public override void OnRemove()
        {
            view.collisionSignal.RemoveListener(onCollision);
        }

        private void onCollision()
        {
            destroyPlayerSignal.Dispatch(view, false);
        }
    }
}
