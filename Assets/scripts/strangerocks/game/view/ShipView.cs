using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class ShipView:View
    {
        public Renderer mainRenderer;
        internal Signal collisionSignal = new Signal();

        void OnTriggerEnter2D()
        {
            Debug.Log("ShipView OnTriggerEnter");
            collisionSignal.Dispatch();
        }
    }


}
