using UnityEngine;

public class ButtonsInstantiation : MonoBehaviour
{
    [SerializeField] private GameObject ButtonPrefab;
    [SerializeField] private GameObject ButtonsParent;

    private Level level;

    void Start()
    {
        level = GetComponent<Level>();
        InstantiateButtons();
    }

    private void InstantiateButtons()
    {
        foreach (GameObject ingredient in level.GivenIngredients)
        {
            GameObject ingredientButton = Instantiate(ButtonPrefab, ButtonsParent.transform, false);
            ingredientButton.GetComponentInChildren<IngredientButton>().Init(ingredient);
        }
    }
}
