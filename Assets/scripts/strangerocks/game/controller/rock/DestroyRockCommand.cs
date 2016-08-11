
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class DestroyRockCommand:Command
    {
        [Inject(GameElement.GAME_FIELD)]
        public GameObject gameField { get; set; }
        [Inject(GameElement.ROCK_POOL)]
        public IPool<GameObject> pool { get; set; }
        [Inject]
        public RockView rockView { get; set; }
        [Inject]
        public bool isPointEarning { get; set; }
        [Inject]
        public IRoutineRunner routineRunner { get; set; }
        [Inject]
        public LevelEndSignal levelEndSignal { get; set; }


        private static Vector2 PARKED_POS = new Vector2(1000f, 1000f);
        public override void Execute()
        {
            if (isPointEarning)
            {
                TestLoadConfig.log.Trace("DestroyRockCommand Execute");

            }
            rockView.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            rockView.GetComponent<Rigidbody2D>().angularVelocity = 0;
            rockView.gameObject.SetActive(false);

            rockView.transform.localPosition = PARKED_POS;
            pool.ReturnInstance(rockView.gameObject);
            if (isPointEarning)
            {
                Retain();
                routineRunner.StartCoroutine(checkRocks());
            }

        }

        public IEnumerator checkRocks()
        {
            yield return null;
            RockView[] rocks = gameField.GetComponentsInChildren<RockView>();
            bool levelCleared = true;
            foreach (RockView rock in rocks)
            {
                if (rock.gameObject.activeSelf) levelCleared = false;
            }
            if (levelCleared) levelEndSignal.Dispatch();
            Release();
        }
    }
}
