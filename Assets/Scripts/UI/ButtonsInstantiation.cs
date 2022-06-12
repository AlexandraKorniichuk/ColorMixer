using UnityEngine;
using UnityEngine.UI;

public class ButtonsInstantiation : MonoBehaviour
{
    [SerializeField] private Button button;
    private Transform ButtonsParent;


    private Level level;

    void Start()
    {
        level = GetComponent<Level>();
        ButtonsParent = GameObject.FindGameObjectWithTag("IngredientButtons").transform;

        InstantiateButtons();
    }

    private void InstantiateButtons()
    {
        foreach (GameObject ingredient in level.GivenIngredients)
        {
            Button ingredientButton = Instantiate(button, ButtonsParent, false);
            ingredientButton.image.sprite = ingredient.GetComponent<IngredientObject>().IngredientSprite;
            ingredientButton.GetComponent<IngredientButton>().IngredientObject = ingredient;
        }
    }
}
