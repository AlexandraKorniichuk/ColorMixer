using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Color LevelColor { get; private set; }
    public List<GameObject> GivenIngredients { get; private set; }
    public List<GameObject> NeededIngredients { get; private set; }

    private LevelController levelController;
    [SerializeField] private PercentageText Percentage;
    private Blender blender;

    void Awake()
    {
        levelController = GetComponent<LevelController>();

        GameObject BlenderObject = GameObject.FindGameObjectWithTag("Blender");
        blender = BlenderObject.GetComponent<Blender>();

        blender.OnMixedColors += ChangeLevel;
       
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
        LevelData CurrentLevel = levelController.Levels[LevelController.CurrentLevel - 1];
        NeededIngredients = CurrentLevel.NeededIngredients;
        GivenIngredients = CurrentLevel.GivenIngredients;
    }

    public void ChangeLevel(Color mixedColor)
    {
        int percentage = Colors.GetPercentage(mixedColor, LevelColor);
        if (percentage > 90)
            levelController.ChangeLevel();
        Percentage.UpdateText(percentage);
    }
}
