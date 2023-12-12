using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;

    public SerializableDictionary<string, bool> hiddenItemsCollected;
    public bool isFirstStageClear;
    public bool isSecondStageClear;
    public bool isThirdStageClear;

    public GameData()
    {
        hiddenItemsCollected = new SerializableDictionary<string, bool>();
        isFirstStageClear = false;
        isSecondStageClear = false;
        isThirdStageClear = false;
    }

    public int GetPercentageComplete()
    {
        int totalCollected = 0;
        foreach (bool collected in hiddenItemsCollected.Values)
        {
            if (collected)
            {
                totalCollected++;
            }
        }

        int percentageCompleted = -1;
        if (hiddenItemsCollected.Count != 0)
        {
            percentageCompleted = (totalCollected * 100 / hiddenItemsCollected.Count);
        }
        return percentageCompleted;
    }
}
