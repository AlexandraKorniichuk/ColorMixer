using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    private Button button;
    private Blender blender;

    public GameObject IngredientObject;

    void Start()
    {
        button = GetComponent<Button>();
        blender = GameObject.FindGameObjectWithTag("Blender").GetComponent<Blender>();

        if (button != null)
            button.onClick.AddListener(() => blender.AddIngredient(IngredientObject));
    }
}
