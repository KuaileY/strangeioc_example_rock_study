using strange.extensions.mediation.impl;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class TestView:View
    {
        [Inject]
        public IScreenUtil screenUtil { get; set; }
        public Renderer mainRender;
        void FixedUpdate()
        {
            if (!!screenUtil.IsInCamera(mainRender.gameObject))
            {
                screenUtil.TranslateToFarSide(gameObject);
            }
        }
    }
}
