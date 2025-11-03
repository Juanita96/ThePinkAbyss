using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class LevelData
{
    public string levelName;
    public bool isActive;
    public int candiesCollected;
}

public class Active_Levels : MonoBehaviour
{
    public static Active_Levels instance;

    public List<LevelData> levels = new List<LevelData>();

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool LevelActive(int levelNumber)
    {
        if (levelNumber >= 0 && levelNumber < levels.Count)
            return levels[levelNumber].isActive;
        return false;
    }

    public void UnlockLevel(int levelNumber)
    {
        if (levelNumber >= 0 && levelNumber < levels.Count)
            levels[levelNumber].isActive = true;
    }

    public void SetCandies(int levelNumber, int amount)
    {
        if (levelNumber >= 0 && levelNumber < levels.Count)
            levels[levelNumber].candiesCollected = amount;
    }

    public int GetCandies(int levelNumber)
    {
        if (levelNumber >= 0 && levelNumber < levels.Count)
            return levels[levelNumber].candiesCollected;
        return 0;
    }
}
