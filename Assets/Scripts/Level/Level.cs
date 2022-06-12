using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject WinPanel;
    [SerializeField] Liquid liquid;

    [SerializeField] private PercentageText PercentageInGame;
    [SerializeField] private PercentageText PercentageAfterGame;
    private LevelController levelController;

    public Color LevelColor { get; private set; }
    public List<GameObject> GivenIngredients { get; private set; }
    public List<GameObject> NeededIngredients { get; private set; }

    private Blender blender;

    void Awake()
    {
        levelController = GetComponent<LevelController>();

        GameObject BlenderObject = GameObject.FindGameObjectWithTag("Blender");
        blender = BlenderObject.GetComponent<Blender>();

        blender.OnMixedColors += ChangeLevelProgress;

        DefineIngredients();
        SetLevelColor();
    }

    private void SetLevelColor()
    {
        LevelColor = Colors.MixColors(GetColors());
        liquid.SetColor(LevelColor);
    }

    private List<Color> GetColors()
    {
        List<Color> currentColors = new List<Color>();

        foreach (GameObject ingredient in NeededIngredients)
            currentColors.Add(ingredient.GetComponent<IngredientObject>().IngredientColor);

        return currentColors;
    }

    private void DefineIngredients()
    {
        LevelData CurrentLevel = levelController.Levels[LevelController.CurrentLevel - 1];
        NeededIngredients = CurrentLevel.NeededIngredients;
        GivenIngredients = CurrentLevel.GivenIngredients;
    }

    public void ChangeLevelProgress(Color mixedColor)
    {
        int percentage = Colors.GetPercentage(mixedColor, LevelColor);
        if (percentage > 90)
            EndLevel(percentage);
        PercentageInGame.UpdateText(percentage);
    }

    private void EndLevel(int percentage)
    {
        WinPanel.SetActive(true);
        PercentageAfterGame.UpdateText(percentage);
    }
}
