using UnityEngine;

public class IngredientObject : MonoBehaviour
{
    public Color IngredientColor;
    public Texture IngredientTexture;

    public void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;
        if(collidedObject.tag == "Blender")
            collidedObject.GetComponent<BlenderEffects>().StartAnimation("IngredientFell");
    }
}
