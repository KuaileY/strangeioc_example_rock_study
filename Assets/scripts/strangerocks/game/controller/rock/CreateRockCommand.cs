using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class CreateRockCommand:Command
    {
        [Inject(GameElement.GAME_FIELD)]
        public GameObject gameField { get; set; }

        [Inject(GameElement.ROCK_POOL)]
        public IPool<GameObject> pool { get; set; }
        [Inject]
        public Vector2 localPos{get;set;}

        public override void Execute()
        {
            TestLoadConfig.log.Trace("CreateRockCommand Execute");
            GameObject rockGo = pool.GetInstance();
            rockGo.SetActive(true);

            rockGo.transform.localPosition = localPos;
            rockGo.transform.localScale = Vector2.one*0.8f;
            rockGo.layer = LayerMask.NameToLayer(MaskLayers.ENEMY.ToString());

            Vector3 expPt = rockGo.transform.localPosition;
            expPt.x += UnityEngine.Random.Range(2f, 4f);
            expPt.x *= (UnityEngine.Random.Range(0f, 1f) < 0.5f) ? -1f : 1f;
            expPt.y += UnityEngine.Random.Range(2f, 4f);
            expPt.y *= (UnityEngine.Random.Range(0f, 1f) < .5f) ? -1f : 1f;
            AddExplosionForce(rockGo.GetComponent<Rigidbody2D>(), UnityEngine.Random.Range(200, 400),
                expPt, 30);

            rockGo.transform.SetParent(gameField.transform);
        }

        private void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
        {
            var dir = (body.transform.position - expPosition);
            float calc = 1 - (dir.magnitude / expRadius);
            if (calc <= 0)
            {
                calc = 0;
            }

            body.AddForce(dir.normalized * expForce * calc);
        }

    }
}
