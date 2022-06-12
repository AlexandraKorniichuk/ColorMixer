using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsInstantiation : MonoBehaviour
{
    [SerializeField] private Button button;
    private Transform ButtonsParent;

    private List<Button> LevelButtons;

    private Level level;
    private LevelController levelController;

    void Start()
    {
        level = GetComponent<Level>();
        levelController = GetComponent<LevelController>();
        ButtonsParent = GameObject.FindGameObjectWithTag("IngredientButtons").transform;

        levelController.OnLevelChanged += DeleteButtons;
        levelController.OnLevelChanged += InstantiateButtons;

        LevelButtons = new List<Button>();
        InstantiateButtons();
    }

    private void DeleteButtons()
    {
        foreach (Button button in LevelButtons)
            Destroy(button.gameObject);
        LevelButtons.Clear();
    }

    private void InstantiateButtons()
    {
        foreach (GameObject ingredient in level.GivenIngredients)
        {
            Button ingredientButton = Instantiate(button, ButtonsParent, false);
            ingredientButton.image.sprite = ingredient.GetComponent<IngredientObject>().IngredientSprite;
            ingredientButton.GetComponent<IngredientButton>().IngredientObject = ingredient;

            LevelButtons.Add(ingredientButton);
        }
    }
}
