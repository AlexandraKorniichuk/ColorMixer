using System;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour
{
    private BlenderEffects effects;

    private List<Color> ColorsInBlender;
    public bool IsNewIngredientContains;

    public Action<Color> OnMixedColors;

    void Start()
    {
        effects = GetComponent<BlenderEffects>();
        effects.OnMixEnded += MixColors;

        ColorsInBlender = new List<Color>();
    }

    public void MixColors()
    {
        if (ColorsInBlender.Count == 0) return;
        
        Color mixedColor = Colors.MixColors(ColorsInBlender);
        if (OnMixedColors != null) OnMixedColors.Invoke(mixedColor);
    }

    public void AddIngredient(GameObject ingredient)
    {
        if (effects.IsEffectsGoing()) return;

        Color ingredientColor = ingredient.GetComponent<IngredientObject>().IngredientColor;
        IsNewIngredientContains = ColorsInBlender.Contains(ingredientColor);
        ColorsInBlender.Add(ingredientColor);

        effects.PrepareForEffects(ingredient);
    }
}