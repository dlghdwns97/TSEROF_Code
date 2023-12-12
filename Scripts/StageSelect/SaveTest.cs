using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    private void Awake()
    {
        DataPersistenceManager.instance.SaveGame();
    }
}
