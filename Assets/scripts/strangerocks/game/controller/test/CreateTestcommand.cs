using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;

namespace Assets.strangerocks.game
{
    public class CreateTestcommand:Command
    {
        [Inject(GameElement.TEST_POOL)]
        public IPool<GameObject> pool { get; set; }
        [Inject]
        public Vector2 localPos { get; set; }
        public override void Execute()
        {
            GameObject testGo = pool.GetInstance();
            testGo.SetActive(true);

            testGo.transform.localPosition = localPos;
            testGo.transform.localScale = Vector2.one;
            testGo.layer = LayerMask.NameToLayer(MaskLayers.ENEMY.ToString());

            testGo.GetComponent<Rigidbody2D>().AddForce(Vector2.left*150f);
        }
    }
}
