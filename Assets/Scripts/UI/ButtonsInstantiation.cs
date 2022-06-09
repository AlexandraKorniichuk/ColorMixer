using UnityEngine;
using UnityEngine.UI;

public class ButtonsInstantiation : MonoBehaviour
{
    [SerializeField] private Button button;
    private Transform ButtonsParent;

    private LevelController levelController;

    void Start()
    {
        levelController = GetComponent<LevelController>();
        levelController.OnLevelChanged += InstantiateButtons;
        ButtonsParent = GameObject.FindGameObjectWithTag("IngredientButtons").transform;
        InstantiateButtons();
    }

    private void InstantiateButtons()
    {
        foreach (GameObject ingredient in levelController.CurrentIngredients)
        {
            Button ingredientButton = Instantiate(button, ButtonsParent, false);
            ingredientButton.image.sprite = ingredient.GetComponent<IngredientObject>().IngredientSprite;
            ingredientButton.GetComponent<IngredientButton>().IngredientObject = ingredient;
        }
    }
}
