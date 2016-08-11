using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.strangerocks.game
{
    public interface IGameModel
    {
        void Reset();
        int lives { get; set; }
        int score { get; set; }
        int initLives { get; set; }
        int level { get; set; }
        bool levelInProgress { get; set; }

    }
}
