using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
        levelController.OnLevelChanged += UpdateText;
        UpdateText();
    }

    private void UpdateText() =>
        text.text = $"LEVEL {levelController.CurrentLevel}";
}
