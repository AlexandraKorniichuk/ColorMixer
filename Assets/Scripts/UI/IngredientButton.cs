using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    public void Init(GameObject ingredient)
    {
        GetComponent<RawImage>().texture = ingredient.GetComponent<IngredientObject>().IngredientTexture;
        AddListener(ingredient);
    }

    private void AddListener(GameObject ingredientObject)
    {
        Button button = GetComponent<Button>();
        Blender blender = GameObject.FindGameObjectWithTag("Blender").GetComponent<Blender>();

        if (button != null)
            button.onClick.AddListener(() => blender.AddIngredient(ingredientObject));
    }
}
