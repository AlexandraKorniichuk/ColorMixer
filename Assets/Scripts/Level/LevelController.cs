using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public List<LevelData> Levels;

    public int CurrentLevel { get; private set; }

    public Action OnLevelChanged;

    void Awake() =>
        CurrentLevel = 1;

    private void ChangeLevel()
    {
        CurrentLevel = CurrentLevel == Levels.Count ? 1 : CurrentLevel + 1;
        if (OnLevelChanged != null) OnLevelChanged.Invoke();
    }
}
