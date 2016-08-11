using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.mediation.impl;

namespace Assets.strangerocks.game
{
    public class RockMediator:Mediator
    {
        [Inject]
        public RockView view { get; set; }
    }
}
