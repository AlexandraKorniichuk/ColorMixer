using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    private Button button;
    public GameObject IngredientObject;

    void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
            button.onClick.AddListener(AddIngredientToBlender);
    }

    private void AddIngredientToBlender()
    {

    }
}
