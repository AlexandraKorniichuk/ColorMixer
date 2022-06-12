using UnityEngine;
using UnityEngine.UI;

public class PercentageText : MonoBehaviour
{
    private Text text;
    void OnEnable() =>
        text = GetComponent<Text>();

    public void UpdateText(int percentage) =>
        text.text = $"{percentage}%";
}
