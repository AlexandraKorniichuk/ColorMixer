using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour
{
    [SerializeField]
    private LevelController levelController;

    private List<GameObject> IngredientsInBlender;

    void Start()
    {
        IngredientsInBlender = new List<GameObject>();
        levelController.OnLevelChanged += ClearBlender;
    }

    public void AddIngredient(GameObject ingredient) =>
        IngredientsInBlender.Add(ingredient);

    private void ClearBlender() =>
        IngredientsInBlender.Clear();
}