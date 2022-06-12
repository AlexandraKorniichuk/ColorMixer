using UnityEngine;

public class ButtonsInstantiation : MonoBehaviour
{
    [SerializeField] private IngredientButton ButtonPrefab;
    [SerializeField] private GameObject ButtonsParent;


    private Level level;

    void Start()
    {
        level = GetComponent<Level>();

        InstantiateButtons();
    }

    private void InstantiateButtons()
    {
        int buttonsCount = level.GivenIngredients.Count;
        foreach (GameObject ingredient in level.GivenIngredients)
        {
            IngredientButton ingredientButton = Instantiate(ButtonPrefab, ButtonsParent.transform, false);
            ingredientButton.Init(ingredient, ButtonsParent, buttonsCount);
        }
    }
}
