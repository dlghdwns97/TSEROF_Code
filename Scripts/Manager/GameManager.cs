using UnityEngine;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public int[] curStage = new int[4] { 0, 1, 2, 3 };
    public int _curStage;

    public bool isSpawn;
    public bool isStartStoryFin;

    public bool isFirstStageClear;
    public bool isSecondStageClear = false;
    public bool isThirdStageClear;

    public static GameManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CurrentStage(int index)
    {
        _curStage = index;
    }

    public void LoadData(GameData data)
    {
        this.isFirstStageClear = data.isFirstStageClear;
        this.isSecondStageClear = data.isSecondStageClear;
        this.isThirdStageClear = data.isThirdStageClear;
    }

    public void SaveData(GameData data)
    {
        data.isFirstStageClear = this.isFirstStageClear;
        data.isSecondStageClear = this.isSecondStageClear;
        data.isThirdStageClear = this.isThirdStageClear;
    }
}
