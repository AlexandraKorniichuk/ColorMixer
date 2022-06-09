using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Sprite> Ingredients;

    private Ingredient[][] LevelsIngredients = new Ingredient[][]
    {
        new Ingredient[] { Ingredient.Apple, Ingredient.Banana },
        new Ingredient[] { Ingredient.Apple, Ingredient.Orange, Ingredient.Cherries },
        new Ingredient[] { Ingredient.Tomato, Ingredient.Cucumber, Ingredient.Eggplant },
    };

    public int CurrentLevel { get; private set; }
    private Sprite[] CurrentIngredients;

    public Action OnLevelChanged;

    void Awake()
    {
        CurrentLevel = 0;
        OnLevelChanged += DefineCurrentIngredients;
        ChangeLevel();
    }

    private void ChangeLevel()
    {
        CurrentLevel = CurrentLevel == 3 ? 1 : CurrentLevel + 1;
        if (OnLevelChanged != null) OnLevelChanged.Invoke();
    }

    private void DefineCurrentIngredients()
    {
        CurrentIngredients = new Sprite[LevelsIngredients[CurrentLevel - 1].Length];
        for(int i = 0; i < LevelsIngredients[CurrentLevel - 1].Length; i++)
        {
            CurrentIngredients[i] = Ingredients[(int)LevelsIngredients[CurrentLevel - 1][i]];
        }
    }
}

public enum Ingredient
{
    Apple,
    Banana, 
    Orange,
    Cherries,
    Tomato,
    Cucumber,
    Eggplant
}
