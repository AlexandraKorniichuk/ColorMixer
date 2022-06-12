using UnityEngine;

public class Liquid : MonoBehaviour
{
    public void SetColor(Color color)
    {
        MeshRenderer Renderer = GetComponent<MeshRenderer>();
        color.a = 0.3f;
        Renderer.materials[0].color = color;
    }
}
