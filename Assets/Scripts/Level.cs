using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public List<Sprite> Ingredients;
    private Ingredient[][] Levels = new Ingredient[][]
    {
        new Ingredient[] { Ingredient.Apple, Ingredient.Banana },
        new Ingredient[] { Ingredient.Apple, Ingredient.Orange, Ingredient.Cherries },
        new Ingredient[] { Ingredient.Tomato, Ingredient.Cucumber, Ingredient.Eggplant },
    };

    private int CurrentLevel;
    private Sprite[] CurrentIngredients;

    void Awake()
    {
        CurrentLevel = 1;
        GetCurrentIngredients();
    }

    private void GetCurrentIngredients()
    {
        for(int i = 0; i < Levels[CurrentLevel - 1].Length; i++)
        {
            CurrentIngredients[i] = Ingredients[(int)Levels[CurrentLevel - 1][i]];
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
