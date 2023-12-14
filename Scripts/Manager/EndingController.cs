using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    [SerializeField] private GameObject hiddenEnding;
    [SerializeField] private GameObject idleEnding;
    
    private GameManager _gameManager;
    private SoundManager _soundManager;
    private DataPersistenceManager _dataPersistenceManager;
    private void Awake()
    {
        hiddenEnding.SetActive(false);
        idleEnding.SetActive(false);

        _gameManager = GameManager.instance;
        _soundManager = SoundManager.instance;
        _dataPersistenceManager = DataPersistenceManager.instance;
    }

    private bool IsHidden()
    {
        return _dataPersistenceManager.gameData.hiddenItemsCollected.Count == 9;
    }

    private void PlayEnding()
    {
        if (IsHidden())
        {
            hiddenEnding.SetActive(true);
        }
        else
        {
            idleEnding.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        _dataPersistenceManager.SaveGame();
        _soundManager.bgSound.Pause();
        PlayEnding();
    }

    public void LoadStageSelectScene()
    {
        _gameManager.isThirdStageClear = true;
        _gameManager.isSpawn = true;
        SceneManager.LoadScene("StageSelect");
    }
}
