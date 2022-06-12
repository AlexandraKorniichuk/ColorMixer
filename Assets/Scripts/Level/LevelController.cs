using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public List<LevelData> Levels;

    public static int CurrentLevel = 1;

    public void ChangeLevel()
    {
        CurrentLevel = CurrentLevel == Levels.Count ? 1 : CurrentLevel + 1;
        SceneManager.LoadScene(0);
    }
}
