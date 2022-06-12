using System;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour
{
    [SerializeField]
    private LevelController levelController;
    private BlenderEffects effects;

    private List<Color> ColorsInBlender;
    public bool IsNewIngredientContains;

    public Action OnMixedColors;
    
    public Color MixedColor { get; private set; }

    void Start()
    {
        effects = GetComponent<BlenderEffects>();
        effects.OnMixEnded += MixColors;

        ColorsInBlender = new List<Color>();
        levelController.OnLevelChanged += ClearBlender;
    }

    public void MixColors()
    {
        if (ColorsInBlender.Count == 0) return;

        MixedColor = Colors.MixColors(ColorsInBlender);
        if (OnMixedColors != null) OnMixedColors.Invoke();
    }

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