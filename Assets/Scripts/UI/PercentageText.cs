using UnityEngine;
using UnityEngine.UI;

public class PercentageText : MonoBehaviour
{
    private Text text;
    void Start() =>
        text = GetComponent<Text>();

    public void UpdateText(int percentage) =>
        text.text = $"{percentage}%";
}
