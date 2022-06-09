using System.Collections.Generic;
using UnityEngine;

public static class Colors 
{
    public static Color MixColors(in List<Color> ColorsInBlender)
    {
        Color MixedColor = new Color();

        foreach (Color color in ColorsInBlender)
            MixedColor += color;

        MixedColor /= ColorsInBlender.Count;

        return MixedColor;
    }

    public static int GetPercentage(Color given, Color needed)
    {
        Color difference = given - needed;
        float differencePersentage = CalculatePersantage(difference);
        return 100 - Mathf.RoundToInt(differencePersentage);
    }

    private static float CalculatePersantage(Color c) =>
        (Mathf.Abs(c.r) + Mathf.Abs(c.g) + Mathf.Abs(c.b) + Mathf.Abs(c.a)) / 1020;
}
