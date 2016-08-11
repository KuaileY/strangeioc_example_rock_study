using System;
using UnityEngine;

namespace Assets.strangerocks
{
    public enum ScreenAnchor
    {
        LEFT,
        RIGHT,
        TOP,
        BOTTOM,
        CENTER_VERTICAL,
        CENTER_HORIZONTAL,
    }
    [Implements(typeof(IScreenUtil))]
    public class ScreenUtil:IScreenUtil
    {
        [Inject(StrangeRocksElement.GAME_CAMERA)]
        public Camera gameCamera { get; set; }
        public Rect GetScreenRect(float x, float y, float width, float height)
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            return new Rect(x*screenWidth, y*screenHeight, width*screenWidth, height*screenHeight);
        }

        public bool IsInCamera(GameObject go)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(gameCamera);
            return GeometryUtility.TestPlanesAABB(planes, go.GetComponent<Renderer>().bounds);
        }

        public void TranslateToFarSide(GameObject go)
        {
            Vector2 pos = go.transform.localPosition;
            Vector2 viewPos = gameCamera.WorldToViewportPoint(pos);
            if (viewPos.x > 1f) viewPos.x = 0.001f;
            if (viewPos.x < 0f) viewPos.x = 0.999f;
            if (viewPos.y > 1f) viewPos.y = 0.001f;
            if (viewPos.y < 0f) viewPos.y = 0.999f;

            Vector2 newPos = gameCamera.ViewportToWorldPoint(viewPos);
            go.transform.localPosition = newPos;
        }

        public Vector2 RandomPositionOnLeft()
        {
            Vector2 viewPos = new Vector2(0f, UnityEngine.Random.Range(0f, 1f));
            Vector2 retv = gameCamera.ViewportToWorldPoint(viewPos);
            return retv;
        }

        public Vector2 GetAnchorPosition(ScreenAnchor hroizontal, ScreenAnchor vertical)
        {
            float x;
            float y;
            switch (hroizontal)
            {
                case ScreenAnchor.LEFT:
                    x = 0;
                    break;
                case ScreenAnchor.CENTER_HORIZONTAL:
                    x = .5f;
                    break;
                case ScreenAnchor.RIGHT:
                    x = 1f;
                    break;
                default:
                    throw new Exception("ScreenUtil.GetAnchorPosition 无效hroizontal值");
            }
            switch (vertical)
            {
                case ScreenAnchor.BOTTOM:
                    y = 0;
                    break;
                case ScreenAnchor.CENTER_VERTICAL:
                    y = .5f;
                    break;
                case ScreenAnchor.TOP:
                    y = 1f;
                    break;
                default:
                    throw new Exception("ScreenUtil.GetAnchorPosition 无效vertical值");
            }
            Vector2 retv = new Vector2(x, y);
            retv = gameCamera.ViewportToWorldPoint(retv);
            return retv;
        }
    }
}
