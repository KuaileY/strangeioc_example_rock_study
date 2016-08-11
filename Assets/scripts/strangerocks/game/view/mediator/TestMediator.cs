using strange.extensions.mediation.impl;

namespace Assets.strangerocks.game
{
    public class TestMediator:Mediator
    {
        [Inject]
        public TestView view { get; set; }
    }
}
