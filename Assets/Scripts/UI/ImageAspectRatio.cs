using UnityEngine;
using UnityEngine.UI;

public class ImageAspectRatio : MonoBehaviour
{
    private RectTransform HLGTransform;
    private HorizontalLayoutGroup HLG;
    private int count;

    public void Init(GameObject hlgObject, int _count)
    {
        HLGTransform = hlgObject.GetComponent<RectTransform>();
        HLG = HLGTransform.GetComponent<HorizontalLayoutGroup>();
        count = _count;
        float size = DefineSize();
        SetSize((int)size); 
    }

    public float DefineSize()
    {
        float hlgW = Camera.main.pixelWidth * (HLGTransform.anchorMax.x - HLGTransform.anchorMin.x);
        float hlgH = Camera.main.pixelHeight * (HLGTransform.anchorMax.y - HLGTransform.anchorMin.y);
        float w = CalculateSize(hlgW);
        float h = CalculateSize(hlgH);

        if (w > h)
            return w > hlgH ? hlgH : w;
        return h > hlgW ? hlgW : h;
    }


    private float CalculateSize(float length) =>
        (length - ((count - 1) * HLG.spacing)) / count;

    public void SetSize(int _size)
    {
        RectTransform transform = GetComponent<RectTransform>();
        Vector2 size = new Vector2(_size, _size);
        transform.sizeDelta = size;
    }
}
