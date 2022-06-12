using UnityEngine;
using UnityEngine.UI;

public class ImageAspectRatio : MonoBehaviour
{
    private RectTransform HLGTransform;
    private HorizontalLayoutGroup HLG;
    private int count;
    //private RawImage Image;

    //void Start()
    //{
        

    //    //if (Image != null && AspectRatioFitter)
    //    //{
    //    //    HorizontalLayoutGroup hlg = GetComponentInParent<HorizontalLayoutGroup>();
    //    //    var y = Image.mainTexture.height;
    //    //    var x = Image.mainTexture.width;
    //    //    //

    //    //    AspectRatioFitter.aspectRatio = y / x;
    //    //}
    //    //else
    //    //{
    //    //    Debug.LogError("Missing RawImage or AspectRatioFitter");
    //    //}
    //}

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
        print($"{Camera.main.pixelWidth}, {Camera.main.pixelHeight}");
        print($"{hlgW}, {hlgH}");
        print($"{w}, {h}");

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
