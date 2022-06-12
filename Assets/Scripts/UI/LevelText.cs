using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
        UpdateText();
    }

    private void UpdateText() =>
        text.text = $"LEVEL {LevelController.CurrentLevel}";
}
