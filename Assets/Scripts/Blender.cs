using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour
{
    [SerializeField]
    private LevelController levelController;
    private BlenderEffects effects;

    private List<Color> ColorsInBlender;
    public bool IsNewIngredientContains;

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
        if (effects.IsEffectsGoing()) return;

        Color ingredientColor = ingredient.GetComponent<IngredientObject>().IngredientColor;
        IsNewIngredientContains = ColorsInBlender.Contains(ingredientColor);
        ColorsInBlender.Add(ingredientColor);

        effects.PrepareForEffects(ingredient);
    }

    private void ClearBlender() =>
        ColorsInBlender.Clear();
}