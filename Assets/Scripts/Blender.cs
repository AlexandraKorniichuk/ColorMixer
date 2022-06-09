using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour
{
    private List<GameObject> IngredientsInBlender;
    void Start()
    {
        IngredientsInBlender = new List<GameObject>();
    }

    public void AddIngredient(GameObject ingredient) =>
        IngredientsInBlender.Add(ingredient);
}