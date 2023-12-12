using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class HiddenItem : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    [SerializeField] private GameObject lockHC;
    [SerializeField] private GameObject unlockHC;

    public AudioSource ItemSFX;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private MeshRenderer _visual;
    private bool _collected = false;

    private void Awake()
    {
        _visual = this.GetComponentInChildren<MeshRenderer>();

        ItemSFX = this.GetComponentInParent<AudioSource>();
    }

    public void LoadData(GameData data)
    {
        data.hiddenItemsCollected.TryGetValue(id, out _collected);
        if (_collected)
        {
            _visual.gameObject.SetActive(false);
            lockHC.SetActive(false);
            unlockHC.SetActive(true);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.hiddenItemsCollected.ContainsKey(id))
        {
            data.hiddenItemsCollected.Remove(id);
        }
        data.hiddenItemsCollected.Add(id, _collected);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!_collected)
            {
                CollectHiddenItem();
                ItemSFX.volume = 0.75f;
                ItemSFX.Play();
            }
        }
    }

    private void CollectHiddenItem()
    {
        _collected = true;
        _visual.gameObject.SetActive(false);
        lockHC.SetActive(false);
        unlockHC.SetActive(true);
    }

}
