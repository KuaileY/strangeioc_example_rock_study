using strange.extensions.mediation.impl;

namespace Assets.strangerocks
{
    public class ButtonMouseMediator:Mediator
    {
        [Inject]
        public ButtonView view { get; set; }

        protected void OnMouseDown()
        {
            view.pressBegan();
        }

        protected void OnMouseUp()
        {
            view.pressEnded();
        }
        protected void OnMouseEnter()
        {
            view.background.GetComponent<UnityEngine.Renderer>().material.color = view.overColor;
        }
        protected void OnMouseExit()
        {
            view.background.GetComponent<UnityEngine.Renderer>().material.color = view.normalColor;
        }
    }
}
