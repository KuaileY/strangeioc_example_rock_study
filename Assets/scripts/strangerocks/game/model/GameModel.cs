using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.strangerocks.game
{
    public class GameModel:IGameModel
    {
        public void Reset()
        {
            score = 0;
            level = 1;
            lives = initLives;
        }

        public int lives { get; set; }
        public int score { get; set; }
        public int initLives { get; set; }
        public int level { get; set; }
        public bool levelInProgress { get; set; }
    }
}
