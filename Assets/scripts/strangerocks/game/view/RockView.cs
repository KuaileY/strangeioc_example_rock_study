using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class RockView:View
    {
        [Inject]
        public IScreenUtil screenUtil { get; set; }

        public Renderer mainRender;
        public float rotationSpeed = 1f;
        void FixedUpdate()
        {
            GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up*rotationSpeed);
            if (!!screenUtil.IsInCamera(mainRender.gameObject))
            {
                screenUtil.TranslateToFarSide(gameObject);
            }
        }
    }
}
