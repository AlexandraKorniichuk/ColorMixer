using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> Ingredients;

    private Ingredient[][] LevelsIngredients = new Ingredient[][]
    {
        new Ingredient[] { Ingredient.Apple, Ingredient.Banana },
        new Ingredient[] { Ingredient.Apple, Ingredient.Orange, Ingredient.Cherries },
        new Ingredient[] { Ingredient.Tomato, Ingredient.Cucumber, Ingredient.Eggplant }
    };
    //private Dictionary<int, Ingredient[]> LevelsIngredients = new Dictionary<int, Ingredient[]>()
    //{
    //    { 1, new Ingredient[] { Ingredient.Apple, Ingredient.Banana } }
    //    { 2, new Ingredient[] { Ingredient.Apple, Ingredient.Orange, Ingredient.Cherries } },
    //    { 3, new Ingredient[] { Ingredient.Tomato, Ingredient.Cucumber, Ingredient.Eggplant } }
    //};
    public int CurrentLevel { get; private set; }
    public  GameObject[] CurrentIngredients { get; private set; }

    public Action OnLevelChanged;

    void Awake()
    {
        CurrentLevel = 0;
        OnLevelChanged += DefineCurrentIngredients;
        ChangeLevel();
    }

    private void ChangeLevel()
    {
        CurrentLevel = CurrentLevel == LevelsIngredients.Length ? 1 : CurrentLevel + 1;
        if (OnLevelChanged != null) OnLevelChanged.Invoke();
    }

    private void DefineCurrentIngredients()
    {
        Ingredient[] ObjectIngredients = LevelsIngredients[CurrentLevel - 1];
        CurrentIngredients = new GameObject[ObjectIngredients.Length];
        for(int i = 0; i < LevelsIngredients[CurrentLevel - 1].Length; i++)
        {
            CurrentIngredients[i] = Ingredients[(int)ObjectIngredients[i]];
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
