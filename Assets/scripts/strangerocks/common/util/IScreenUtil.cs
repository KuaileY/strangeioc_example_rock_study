using UnityEngine;

namespace Assets.strangerocks
{
    public interface IScreenUtil
    {
        Rect GetScreenRect(float x, float y, float width, float height);
        bool IsInCamera(GameObject go);
        void TranslateToFarSide(GameObject go);
        Vector2 RandomPositionOnLeft();
        Vector2 GetAnchorPosition(ScreenAnchor hroizontal,ScreenAnchor vertical);
    }
}
