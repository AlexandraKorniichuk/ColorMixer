using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Color LevelColor { get; private set; }
    public List<GameObject> GivenIngredients { get; private set; }
    public List<GameObject> NeededIngredients { get; private set; }

    private LevelController levelController;

    void Awake()
    {
        levelController = GetComponent<LevelController>();
        levelController.OnLevelChanged += DefineIngredients;
        levelController.OnLevelChanged += SetLevelColor;

        DefineIngredients();
        SetLevelColor();
    }

    private void SetLevelColor() =>
        LevelColor = Colors.MixColors(GetColors());

    private List<Color> GetColors()
    {
        List<Color> currentColors = new List<Color>();

        foreach (GameObject ingredient in NeededIngredients)
            currentColors.Add(ingredient.GetComponent<IngredientObject>().IngredientColor);

        return currentColors;
    }

    private void DefineIngredients()
    {
        LevelData CurrentLevel = levelController.Levels[levelController.CurrentLevel - 1];
        NeededIngredients = CurrentLevel.NeededIngredients;
        GivenIngredients = CurrentLevel.GivenIngredients;
    }
}
