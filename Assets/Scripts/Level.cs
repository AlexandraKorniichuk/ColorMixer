using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Color LevelColor { get; private set; }

    private LevelController levelController;

    void Start()
    {
        levelController = GetComponent<LevelController>();
        levelController.OnLevelChanged += SetLevelColor;
        SetLevelColor();
    }

    private void SetLevelColor() =>
        LevelColor = Colors.MixColors(GetColors());

    private List<Color> GetColors()
    {
        List<Color> currentColors = new List<Color>();

        foreach (GameObject ingredient in levelController.CurrentIngredients)
            currentColors.Add(ingredient.GetComponent<IngredientObject>().IngredientColor);

        return currentColors;
    }
}
