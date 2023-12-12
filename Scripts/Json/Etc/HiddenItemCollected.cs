using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenItemCollected : MonoBehaviour, IDataPersistence
{
    [SerializeField] private int totalHiddenItems = 0;

    private int _hiddenItemsCollected = 0;

    private Text _hiddenItemsCollectedText;

    private void Awake()
    {
        _hiddenItemsCollectedText = this.GetComponent<Text>();
    }

    private void Start()
    {
        GameEventsManager.instance.onHiddenItemCollected += OnHiddenItemCollected;
    }

    public void LoadData(GameData data)
    {
        foreach (KeyValuePair<string, bool> pair in data.hiddenItemsCollected)
        {
            if (pair.Value)
            {
                _hiddenItemsCollected++;
            }
        }
    }

    public void SaveData(GameData data)
    {

    }

    private void OnDestroy()
    {
        GameEventsManager.instance.onHiddenItemCollected -= OnHiddenItemCollected;
    }

    private void OnHiddenItemCollected()
    {
        _hiddenItemsCollected++;
    }

    private void Update()
    {
        _hiddenItemsCollectedText.text = _hiddenItemsCollected + " / " + totalHiddenItems;
    }
}
