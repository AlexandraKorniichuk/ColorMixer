using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour
{
    [SerializeField]
    private LevelController levelController;
    private BlenderEffects effects;

    private List<Color> ColorsInBlender;

    private Color MixedColor;

    void Start()
    {
        effects = GetComponent<BlenderEffects>();

        ColorsInBlender = new List<Color>();
        levelController.OnLevelChanged += ClearBlender;
    }

    public void MixColors() =>
        MixedColor = Colors.MixColors(ColorsInBlender);

    public void AddIngredient(GameObject ingredient)
    {
        ColorsInBlender.Add(ingredient.GetComponent<IngredientObject>().IngredientColor);
        effects.SetObject(ingredient);
        effects.StartAnimation("Open");
    }

    private void ClearBlender() =>
        ColorsInBlender.Clear();
}