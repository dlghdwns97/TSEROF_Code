using UnityEngine;

public class RunSFX : MonoBehaviour
{
    public AudioSource runSFX;
    public AudioClip[] runSFXList;
    
    public Player player;

    public bool _isRunning = false;

    private void Awake()
    {
        runSFX = GetComponent<AudioSource>();
    }

    public void OnGrass()
    {
        OnRunSFX(runSFXList[0]); 
    }
    public void OnRock()
    {
        OnRunSFX(runSFXList[1]);
    }
    public void OnWood()
    {
        OnRunSFX(runSFXList[2]);
    }
    public void OnIce()
    {
        OnRunSFX(runSFXList[3]);
    }
    public void OnLava()
    {
        OnRunSFX(runSFXList[4]);
    }
    public void OnWater()
    {
        OnRunSFX(runSFXList[5]);
    }

    public void OnRunSFX()
    {
        OnRunSFX(runSFX.clip);
    }

    public void OnRunSFX(AudioClip audioClip)
    {
        runSFX.clip = audioClip;
        if (_isRunning == true)
        {
            if(!runSFX.isPlaying)
            {
                runSFX.volume = 1f;
                runSFX.Play();
            }
        }
        else if (_isRunning == false)
        {
            runSFX.Stop();
        }
    }
}
