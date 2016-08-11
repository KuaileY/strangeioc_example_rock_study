using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class GameDebugView:View
    {
        internal enum ScreenState
        {
            IDLE,
            START_LEVEL,
            END_GAME,
            LEVEL_IN_PROGRESS,
        }

        [Inject]
        public IScreenUtil screenUtil { get; set; }

        internal Signal startGameSignal = new Signal();
        internal Signal startLevelSignal = new Signal();

        private ScreenState state = ScreenState.IDLE;

        private int score;
        private int lives;
        private int level;
        public void OnGUI()
        {
            switch (state)
            {
                case ScreenState.IDLE:
                    if (GUI.Button(screenUtil.GetScreenRect(.4f, .45f, .2f, .1f), "Start Game"))
                    {
                        startGameSignal.Dispatch();
                    }
                    GUI.TextField(screenUtil.GetScreenRect(0f, 0f, .4f, .05f), "Last Score: " + score);
                    break;
                case ScreenState.START_LEVEL:
                    if (GUI.Button(screenUtil.GetScreenRect(.4f, .45f, .2f, .05f), "Start Level"+level))
                    {
                        startLevelSignal.Dispatch();
                    }
                    GUI.TextField (screenUtil.GetScreenRect (.4f, .5f, .4f, .05f), "Score: " + score);
				    GUI.TextField (screenUtil.GetScreenRect (.4f, .55f, .4f, .05f), "Lives remaining: " + lives);
                    break;
                case ScreenState.LEVEL_IN_PROGRESS:
                    GUI.TextField (screenUtil.GetScreenRect (0f, 0f, .4f, .05f), "Score: " + score);
				    GUI.TextField (screenUtil.GetScreenRect (.6f, 0f, .4f, .05f), "Lives Remaining: " + lives);
				    //GUI.TextField (screenUtil.GetScreenRect (0f, .95f, .2f, .05f), "Level: " + level);
				    break;
                case ScreenState.END_GAME:
                    if (GUI.Button(screenUtil.GetScreenRect(.4f, .45f, .2f, .05f), "Play Again"))
                    {
                        startGameSignal.Dispatch();
                    }
                    GUI.TextField(screenUtil.GetScreenRect(.4f, .5f, .4f, .05f), "Final Score: " + score);
                    break;
            }
        }

        internal void SetState(ScreenState state)
        {
            this.state = state;
        }

        internal void SetLives(int lives)
        {
            this.lives = lives;
        }

        internal void SetScore(int score)
        {
            this.score = score;
        }

        internal void SetLevel(int level)
        {
            this.level = level;
        }
    }
}
