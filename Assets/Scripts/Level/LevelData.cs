using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data", order = 51)]
public class LevelData : ScriptableObject
{
    public List<GameObject> NeededIngredients;
    public List<GameObject> GivenIngredients;
}
