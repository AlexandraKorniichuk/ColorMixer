using UnityEngine;

public class IngredientObject : MonoBehaviour
{
    public Color IngredientColor;
    public Sprite IngredientSprite;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Blender")
            collision.gameObject.GetComponent<BlenderEffects>().StartStaggering();
    }
}
